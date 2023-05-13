using Lookif.Library.Common.Exceptions;
using Microsoft.AspNetCore.Identity;
using Lookif.Layers.Service.Services.Base;
using Lookif.Layers.Core.MainCore.Identities;
using Lookif.Layers.Core.Infrastructure.Base;
using Lookif.Layers.Core.Else.JWT;
using SimpleExpenseManagement.Core.Infrastructure.Users;
using SimpleExpenseManagement.Data.Repositories.Interfaces;
namespace SimpleExpenseManagement.Service.Services.UserServices
{
    public class UserService : BaseService<User, Guid>, IUserService, IScopedDependency
    { 
        private readonly IUserRepository repository;
        private readonly UserManager<User> userManager;
        private readonly IJwtService jwtService;
 

        public UserService(IUserRepository repository, UserManager<User> userManager, IJwtService jwtService) : base(repository)
        {
            this.repository = repository;
            this.userManager = userManager;
            this.jwtService = jwtService;
     
        }


        public override async Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var user = await base.GetByIdAsync(id, cancellationToken);
            if (user == null)
                return null;
            await repository.UpdateSecuirtyStampAsync(user, cancellationToken);
            return user;
        }


        public async Task<User> FindByNameAsync(string userName, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(userName);
            return user;
        }

        public async Task<User> CheckPasswordByUserNameAsync(string userName, string password, CancellationToken cancellationToken)
        {
            var user = await this.FindByNameAsync(userName, cancellationToken);
            if (user is null)
                throw new BadRequestException("نام کاربری یا رمز عبور اشتباه است");
            if (user.Block)
                throw new BadRequestException("کاربر غیر فعال است");
            var isPasswordValid = await userManager.CheckPasswordAsync(user, password);
            if (!isPasswordValid)
                throw new BadRequestException("نام کاربری یا رمز عبور اشتباه است");

            return user;
        }


        public async Task<User> AddOrUpdateDummyUserAsync(
            string userName,
            string Name,
            string FamilyName,
            string PhoneNo,
            CancellationToken cancellationToken,
            bool save = true
            )
        {
            var user = GetAll().Where(x => x.UserName == userName).FirstOrDefault();
            if (user is not null)
                return user;

            var u = new User()
            {
                UserName = userName, 
                FullName = $"{Name} {FamilyName}",
                Email = $"{userName}@A.com",
                NormalizedEmail = $"{userName}@A.com".ToUpper(),
                PhoneNumber = PhoneNo,
                PasswordHash = userName + "123qwe!@#"
            };

            return await AddAsync(u, cancellationToken, save);
        }




        public async Task<AccessToken> CreateToken(string userName, string password, CancellationToken cancellationToken)
        {
            var user = await this.CheckPasswordByUserNameAsync(userName, password, cancellationToken);
            var jwt = await jwtService.GenerateAsync(user);
            return jwt;

        }

        public override async Task<User> AddAsync(User user, CancellationToken cancellationToken, bool save = true)
        {
            var exists = await this.FindByNameAsync(user.UserName, cancellationToken);
            if (!(exists is null))
                throw new BadRequestException("نام کاربری تکراری است");
            var res = await userManager.CreateAsync(user, user.PasswordHash);
            if (!res.Succeeded)
            {

                var errorMessages = res.Errors.Select(p => p.Description);

                throw new BadRequestException(string.Join(" | ", errorMessages));
            }

            await userManager.AddToRoleAsync(user, "User");
            return user;
        }

        public override async Task<User> DeleteAsync(User t, CancellationToken cancellationToken, bool save = true)
        {
            var user = await repository.GetByIdAsync(cancellationToken, t.Id);
            return await base.DeleteAsync(user, cancellationToken, save);
        }


        public async Task ResetPassword(string userName, string userGmail, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(userName);
            
            if (user.Email != userGmail)
                throw new BadRequestException("نام کاربری یا ایمیل موجود نیست");
            
            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var res = await userManager.ResetPasswordAsync(user, token, user.Email);
            
            if (!res.Succeeded)
                throw new BadRequestException(string.Join(" | ", res.Errors.Select(p => p.Description)));
        }


        public async Task ResetPasswordViaId(int id, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            await userManager.ResetPasswordAsync(user, token, user.Email);

        }


        
        public async Task ChangePassword(User u, string currentPassword, string newPassword)
        {
            var res = await userManager.ChangePasswordAsync(u, currentPassword, newPassword);

            if (!res.Succeeded)
            {

                var errorMessages = res.Errors.Select(p => p.Description);

                throw new BadRequestException(string.Join(" | ", errorMessages));
            }
        }






    }
}
