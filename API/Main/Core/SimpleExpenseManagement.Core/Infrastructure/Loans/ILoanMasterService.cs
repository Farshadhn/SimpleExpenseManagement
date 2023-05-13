using SimpleExpenseManagement.Core.Models.Loans;
using Lookif.Layers.Core.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.Core.Infrastructure.Loans
{
    public interface ILoanMasterService : IBaseService<LoanMaster, Guid>, IScopedDependency
    {
    }
}
