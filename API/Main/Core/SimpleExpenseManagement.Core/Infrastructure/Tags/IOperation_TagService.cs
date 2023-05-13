using SimpleExpenseManagement.Core.Models.Tags;
using Lookif.Layers.Core.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.Core.Infrastructure.Tags
{
    public interface IOperation_TagService : IBaseService<Operation_Tag, Guid>, IScopedDependency
    {
    }
}
