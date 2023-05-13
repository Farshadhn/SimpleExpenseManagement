using SimpleExpenseManagement.Constants.Enums;
using SimpleExpenseManagement.Core.Models.Accounts;
using SimpleExpenseManagement.Core.Models.Units;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimpleExpenseManagement.Core.Models.Investments;

public class Investment : BaseEntity<Guid>, IActive
{
    public Account Account { get; set; }
    [ForeignKey(nameof(AccountId))]
    public Guid AccountId { get; set; }

    public decimal FromAmount { get; set; }
    public Unit FromUnit { get; set; }
    [ForeignKey(nameof(FromUnitId))]
    public Guid FromUnitId { get; set; }

    public decimal ToAmount { get; set; }
    public Unit ToUnit { get; set; }
    [ForeignKey(nameof(ToUnitId))]
    public Guid ToUnitId { get; set; }

    public string Address{ get; set; }
    public DateTime DateTime { get; set; }

    public TypeOfOperation TypeOfOperation { get; set; }
    public bool IsActive { get ; set; }
}
public class InvestmentConfiguration : IEntityTypeConfiguration<Investment>
{
    public void Configure(EntityTypeBuilder<Investment> builder)
    {
        builder.Property(x => x.FromAmount).HasPrecision(18, 0);
        builder.Property(x => x.ToAmount).HasPrecision(18, 0);

    }
}
