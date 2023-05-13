
using SimpleExpenseManagement.Core.Models.Operations;
using Lookif.Layers.Core.MainCore.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace SimpleExpenseManagement.Core.Models.Tags;

public class Tag : BaseEntity<Guid>, IActive
{
    public string Title { get; set; }
    public string Color { get; set; }
    public virtual ICollection<Operation_Tag> Operations{ get; set; }
    public bool IsActive { get ; set ; }
}


public class Operation_Tag : BaseEntity<Guid>, IActive
{
    public Guid OperationId { get; set; }
    [ForeignKey(nameof(OperationId))]
    public Operation Operation { get; set; }


    public Guid TagId { get; set; }
    [ForeignKey(nameof(TagId))]
    public Tag Tag { get; set; }
    public bool IsActive { get ; set; }
}

