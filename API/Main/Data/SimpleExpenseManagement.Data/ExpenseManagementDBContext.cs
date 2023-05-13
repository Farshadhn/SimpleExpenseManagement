using SimpleExpenseManagement.Core;
using Lookif.Layers.Data;
using Microsoft.EntityFrameworkCore;


namespace SimpleExpenseManagement.Data;
public class SimpleExpenseManagementDBContext : ApplicationDbContext
{
    public SimpleExpenseManagementDBContext(DbContextOptions options)
    : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        CoreLayerAssembly = typeof(Test).Assembly;// We need just this dummy file to address all CoreModels.

        base.OnConfiguring(optionsBuilder);
    }



}