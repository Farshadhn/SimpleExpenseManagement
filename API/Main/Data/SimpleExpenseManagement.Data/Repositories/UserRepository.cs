using Lookif.Library.Common.Exceptions;
using Lookif.Library.Common.Utilities;
using Microsoft.EntityFrameworkCore;
using Lookif.Layers.Core.Infrastructure.Base;
using Lookif.Layers.Data.Repositories;
using Lookif.Layers.Core.MainCore.Identities;
using Lookif.Layers.Core.Infrastructure.Base.Repositories;
using SimpleExpenseManagement.Data.Repositories.Interfaces;

namespace SimpleExpenseManagement.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository, IScopedDependency, IUserRelated
    {
        public UserRepository(SimpleExpenseManagementDBContext dbContext)
            : base(dbContext)
        {
        }

        public Task<User> GetByUserAndPass(string username, string password, CancellationToken cancellationToken)
        {
            var passwordHash = SecurityHelper.GetSha256Hash(password);
            return Table.Where(p => p.UserName == username && p.PasswordHash == passwordHash).SingleOrDefaultAsync(cancellationToken);
        }

        public Task UpdateSecuirtyStampAsync(User user, CancellationToken cancellationToken)
        {
            user.SecurityStamp = Guid.NewGuid().ToString();
            return base.UpdateAsync(user, cancellationToken);
        }

        public override void Update(User entity, bool saveNow = true)
        {
            entity.SecurityStamp = Guid.NewGuid().ToString();
            base.Update(entity, saveNow);
        }

        public Task UpdateLastLoginDateAsync(User user, CancellationToken cancellationToken)
        {
            //user.LastLoginDate = DateTimeOffset.Now;
            return UpdateAsync(user, cancellationToken);
        }

        public async Task AddAsync(User user, string password, CancellationToken cancellationToken)
        {
            var exists = await TableNoTracking.AnyAsync(p => p.UserName == user.UserName);
            if (exists)
                throw new BadRequestException("نام کاربری تکراری است");

            var passwordHash = SecurityHelper.GetSha256Hash(password);
            user.PasswordHash = passwordHash;
            await base.AddAsync(user, cancellationToken);
        }

        public Task<User> GetById(Guid id, CancellationToken cancellationToken)
        {
            return Table.Where(p => p.Id == id && !p.IsDeleted).SingleOrDefaultAsync(cancellationToken);
        }
    }
}
