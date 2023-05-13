using SimpleExpenseManagement.Core.Infrastructure.Events;
using SimpleExpenseManagement.Core.Models.Events;
using Lookif.Layers.Core.Infrastructure.Base;
using Lookif.Layers.Core.Infrastructure.Base.Repositories;
using Lookif.Layers.Service.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.Service.Services.Events
{
    public class EventService : BaseService<Event, Guid>, IEventService, IScopedDependency
    {
        private readonly IRepository<Event> _repository;

        public EventService(IRepository<Event> repository) : base(repository)
        {
            _repository = repository;
        }
                    
    }
}
