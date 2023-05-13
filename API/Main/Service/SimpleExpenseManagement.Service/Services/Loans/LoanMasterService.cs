using SimpleExpenseManagement.Core.Infrastructure.Loans;
using SimpleExpenseManagement.Core.Models.Loans;
using Lookif.Layers.Core.Infrastructure.Base;
using Lookif.Layers.Core.Infrastructure.Base.Repositories;
using Lookif.Layers.Service.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.Service.Services.Loans
{
    public class LoanMasterService : BaseService<LoanMaster, Guid>, ILoanMasterService, IScopedDependency
    {
        private readonly IRepository<LoanMaster> _repository;

        public LoanMasterService(IRepository<LoanMaster> repository) : base(repository)
        {
            _repository = repository;
        }
    


    }
}
