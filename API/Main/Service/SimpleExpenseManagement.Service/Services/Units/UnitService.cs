using SimpleExpenseManagement.Core.Infrastructure.Units;
using SimpleExpenseManagement.Core.Models.Units;
using Lookif.Layers.Core.Infrastructure.Base;
using Lookif.Layers.Core.Infrastructure.Base.Repositories;
using Lookif.Layers.Service.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.Service.Services.Units
{
    public class UnitService : BaseService<Unit, Guid>, IUnitService, IScopedDependency
    {
        private readonly IRepository<Unit> _repository;

        public UnitService(IRepository<Unit> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
