
using SimpleExpenseManagement.Core.Models.Operations;
using Lookif.Layers.Core.MainCore.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace SimpleExpenseManagement.Core.Models.Tags;

public class Tag : BaseEntity<Guid>, IActive
{
    public string Title { get; set; }
    public string Color { get; set; }
    public bool IsActive { get ; set ; }
}

 

