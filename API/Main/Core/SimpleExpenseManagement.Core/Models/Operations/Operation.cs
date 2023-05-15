using SimpleExpenseManagement.Constants.Enums;
using SimpleExpenseManagement.Core.Models.Accounts;
using SimpleExpenseManagement.Core.Models.Tags;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SimpleExpenseManagement.Core.Models.Operations;

public class Operation : BaseEntity<Guid>, IActive
{
    public Account From{ get; set; }
    [ForeignKey(nameof(FromId))]
    public Guid? FromId { get; set; } 

    public Account  To{ get; set; }
    [ForeignKey(nameof(ToId))]
    public Guid? ToId { get; set; }
    public DateTime DateTime{ get; set; }
    public decimal Amount { get; set; }
    public TypeOfOperation TypeOfOperation{ get; set; }
    public string Definition { get; set; }


    public Tag Tag { get; set; }
    [ForeignKey(nameof(TagId))]
    public Guid? TagId { get; set; }
     
    public bool IsActive { get; set ; }


    public Guid? UserId { get; set; }
}
public class OperationConfiguration : IEntityTypeConfiguration<Operation>
{
    public void Configure(EntityTypeBuilder<Operation> builder)
    {
        builder.Property(x => x.Amount).HasPrecision(18, 0); 

    }
}
