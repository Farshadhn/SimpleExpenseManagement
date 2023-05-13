using SimpleExpenseManagement.Core.Models.Events;
using Lookif.Layers.Core.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.Core.Infrastructure.Events
{
    public interface IEventService : IBaseService<Event, Guid>, IScopedDependency
    {
    }
}
