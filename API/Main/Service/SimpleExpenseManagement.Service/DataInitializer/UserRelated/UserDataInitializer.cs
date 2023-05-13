using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Lookif.Layers.Core.Infrastructure.Base.DataInitializer;
using Lookif.Layers.Core.MainCore.Identities;
using Lookif.Layers.Core.Enums;
using SimpleExpenseManagement.Core.Infrastructure.Users;

namespace SimpleExpenseManagement.Service.DataInitializer.UserRelated;

public class UserDataInitializer : IDataInitializer
{
    private readonly UserManager<User> userManager;

    public UserDataInitializer(UserManager<User> userManager, IUserService userService)
    {
        this.userManager = userManager;
        UserService = userService;
    }
    public int order { get; set; } = 2;
    public IUserService UserService { get; }

    public void InitializeData()
    {
        if (!userManager.Users.AsNoTracking().Any(p => p.UserName == "Admin"))
        {
            var user = new User
            {
                LastEditedUserId = default,
                Age = 25,
                FullName = "Admin",
                Gender = GenderType.Male,
                UserName = "admin",
                Email = "admin@site.com",
                LastEditedDateTime = DateTime.Now
            };
            var result = userManager.CreateAsync(user, "1234567Aa@").GetAwaiter().GetResult();
        }   
        if (!userManager.Users.AsNoTracking().Any(p => p.UserName == "SystemUser"))
        {
            var user = new User
            {
                LastEditedUserId = default,
                Age = 25,
                FullName = "خودکار",
                Gender = GenderType.Male,
                UserName = "SystemUser",
                Email = "SystemUser@site.com",
                LastEditedDateTime = DateTime.Now
            };
            var result = userManager.CreateAsync(user, "1234567Aa@").GetAwaiter().GetResult();
        }
        if (!userManager.Users.AsNoTracking().Any(p => p.UserName == "farshad"))
        {
            var user = new User
            {
                LastEditedUserId = default,
                Age = 25,
                FullName = "Farshad hn",
                Gender = GenderType.Male,
                UserName = "farshad",
                Email = "Farshad@site.com",
                LastEditedDateTime = DateTime.Now
            };

            var result = userManager.CreateAsync(user, "1234567Aa@").GetAwaiter().GetResult();
        }
        
    }
}
