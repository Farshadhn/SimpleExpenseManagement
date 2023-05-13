using Lookif.Layers.Core.Else.JWT;
using Lookif.Layers.Core.Infrastructure.Base;
using Lookif.Layers.Core.MainCore.Identities;
using Lookif.Library.Common;  
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.Core.Infrastructure.Users
{
    public interface IUserService : IBaseService<User, Guid>, IScopedDependency
    {
      
        /// <summary>
        /// Creates JWT Token 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<AccessToken> CreateToken(string username, string password, CancellationToken cancellationToken);

        /// <summary>
        /// Find User by its name
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<User> FindByNameAsync(string userName, CancellationToken cancellationToken);

        /// <summary>
        /// To Make sure that this user is authenticated
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<User> CheckPasswordByUserNameAsync(string userName, string password, CancellationToken cancellationToken);

        Task ChangePassword(User u, string currentPassword, string newPassword);

        /// <summary>
        /// This one is used for users to change their password
        /// </summary>
        /// <param name="id">user's id</param>
        /// <param name="userGmail"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task ResetPassword(string userName, string userGmail, CancellationToken cancellationToken);

        /// <summary>
        /// This one is used for Admins to change users password
        /// </summary>
        /// <param name="id">user's id</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task ResetPasswordViaId(int id, CancellationToken cancellationToken);


        /// <summary>
        /// When you want to save a dummy user and just want to have a user and test
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="Name"></param>
        /// <param name="FamilyName"></param>
        /// <param name="PhoneNo"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="save"></param>
        /// <returns></returns>
        Task<User> AddOrUpdateDummyUserAsync(string userName, string Name, string FamilyName, string PhoneNo, CancellationToken cancellationToken, bool save);
    }
}
