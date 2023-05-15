using SimpleExpenseManagement.Core.Models.Units;
using Lookif.Layers.Core.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.Core.Infrastructure.Units;

public interface IUnitService : IBaseService<Unit, Guid>, IScopedDependency
{
}
