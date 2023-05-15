using SimpleExpenseManagement.Core.Models.Accounts;
using Lookif.Layers.Core.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.Core.Infrastructure.Accounts;

public interface IAccountVisibilityService : IBaseService<AccountVisibility, Guid>, IScopedDependency
{
}
