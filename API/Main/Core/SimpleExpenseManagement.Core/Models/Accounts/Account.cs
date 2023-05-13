using SimpleExpenseManagement.Constants.Enums;
using SimpleExpenseManagement.Core.Models.Users;
using Lookif.Layers.Core.MainCore.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleExpenseManagement.Core.Models.Accounts;

public class Account : BaseEntity<Guid> , IActive
{
    public decimal InitialValue { get; set; } = 0;
    public string Title { get; set; }
    public AccountVisibilityStatus AccountVisibilityStatus { get; set; }
    public bool IsActive { get; set; } = true;

}

  public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(x => x.InitialValue).HasPrecision(18, 0); 

        }
    }