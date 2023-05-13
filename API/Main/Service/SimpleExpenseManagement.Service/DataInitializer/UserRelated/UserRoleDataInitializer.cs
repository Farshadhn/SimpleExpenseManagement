using Lookif.Layers.Core.Infrastructure.Base.DataInitializer;
using Lookif.Layers.Core.MainCore.Identities;
using Microsoft.AspNetCore.Identity; 

namespace SimpleExpenseManagement.Service.DataInitializer.UserRelated;

internal class UserRoleDataInitializer : IDataInitializer
{
    public UserRoleDataInitializer(UserManager<User> userManager)
    {
        UserManager = userManager;
    }

    public UserManager<User> UserManager { get; }
    public int order { get; set; } = 3;

    public void InitializeData()
    { 

        var AdminUser = UserManager.FindByNameAsync("admin").ConfigureAwait(false).GetAwaiter().GetResult();
        bool DoesUserAdminUserExits = AdminUser is not default(User);
        Thread.Sleep(200);
        if (DoesUserAdminUserExits)
        {
            UserManager.AddToRoleAsync(AdminUser, "Admin").ConfigureAwait(false).GetAwaiter().GetResult();
        }

        Thread.Sleep(200);


        var SystemUser = UserManager.FindByNameAsync("SystemUser").ConfigureAwait(false).GetAwaiter().GetResult();
 
        bool DoesUserSystemUserExits = SystemUser is not default(User);
        Thread.Sleep(200);
        if (DoesUserSystemUserExits)
        {
            UserManager.AddToRoleAsync(SystemUser, "System").ConfigureAwait(false).GetAwaiter().GetResult();
        }


 
    }
}
