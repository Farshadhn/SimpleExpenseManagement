using SimpleExpenseManagement.Core.Models.Investments;
using Lookif.Layers.Core.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.Core.Infrastructure.Investments
{
    public interface IInvestmentService : IBaseService<Investment, Guid>, IScopedDependency
    {
    }
}
