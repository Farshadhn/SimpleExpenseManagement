using Lookif.Layers.Core.MainCore.Identities;
using Lookif.Layers.Core.Infrastructure.Base.DataInitializer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SimpleExpenseManagement.Service.DataInitializer;

public class RoleDataInitializer : IDataInitializer
{
    private readonly RoleManager<Role> roleManager;

    public RoleDataInitializer(RoleManager<Role> roleManager)
    {
        this.roleManager = roleManager;
    }

    public int order { get; set; } = 1;

    public void InitializeData()
    {
        if (!roleManager.Roles.AsNoTracking().Any(p => p.Name == "System"))
        {
            var Role = new Role() { Name = "System", NormalizedName = "SYSTEM", Description = "This Role Is used for system works" };
            var result = roleManager.CreateAsync(Role).GetAwaiter().GetResult();
        }
        if (!roleManager.Roles.AsNoTracking().Any(p => p.Name == "Admin"))
        {
            var Role = new Role() { Name = "Admin", NormalizedName = "ADMIN", Description = "This Role Has all abilities" };
            var result = roleManager.CreateAsync(Role).GetAwaiter().GetResult();
        }
        if (!roleManager.Roles.AsNoTracking().Any(p => p.Name == "User"))
        {
            var Role = new Role() { Name = "User", NormalizedName = "USER", Description = "This Role is Normal one" };
            var result = roleManager.CreateAsync(Role).GetAwaiter().GetResult();
        }
       
    }
}
