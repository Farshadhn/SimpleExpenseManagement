using SimpleExpenseManagement.Core.Models.Operations;
using Lookif.Layers.Core.MainCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.Core.Models.Events;

public class Event : BaseEntity<Guid>, IActive
{
    public string EventTitle { get; set; }
    public string EventDefinition { get; set; }
    public virtual ICollection<Operation> Operations { get; set; }
    public bool IsActive { get; set; }
}
