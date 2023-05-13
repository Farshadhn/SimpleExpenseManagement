using SimpleExpenseManagement.Core.Models.Operations;
using Lookif.Layers.Core.MainCore.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleExpenseManagement.Core.Models.Loans;
public class LoanMaster : BaseEntity<Guid>, IActive
{
    public int Count { get; set; }
    [Range(0, 100)]
    public int InterestRate { get; set; }
    public string Title{ get; set; }
    public string Definition { get; set; }
    public decimal Freeze { get; set; }
    public virtual ICollection<LoanDetail> LoanDetails { get; set; }

    public Guid? OperationId { get; set; }
    [ForeignKey(nameof(OperationId))]
    public Operation Operation { get; set; }
    public bool IsActive { get ; set; }
}
public class LoanMasterConfiguration : IEntityTypeConfiguration<LoanMaster>
{
    public void Configure(EntityTypeBuilder<LoanMaster> builder)
    {
        builder.Property(x => x.Freeze).HasPrecision(18, 0);

    }
}
public class LoanDetail : BaseEntity<Guid>, IActive
{

    public Guid? OperationId { get; set; }
    [ForeignKey(nameof(OperationId))]
    public Operation Operation { get; set; }  

    public Guid LoanMasterId { get; set; }
    [ForeignKey(nameof(LoanMasterId))]
    public LoanMaster LoanMaster { get; set; }


    public decimal Amount { get; set; }
    public decimal Paid { get; set; }
    public DateTime DueTime { get; set; }
    public DateTime? PaidDateTime { get; set; }
    public bool IsActive { get; set; }
}
public class LoanDetailConfiguration : IEntityTypeConfiguration<LoanDetail>
{
    public void Configure(EntityTypeBuilder<LoanDetail> builder)
    {
        builder.Property(x => x.Amount).HasPrecision(18, 0);
        builder.Property(x => x.Paid).HasPrecision(18, 0);

    }
}