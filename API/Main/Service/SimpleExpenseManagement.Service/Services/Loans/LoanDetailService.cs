using SimpleExpenseManagement.Core.Infrastructure.Loans;
using SimpleExpenseManagement.Core.Models.Loans;
using Lookif.Layers.Core.Infrastructure.Base;
using Lookif.Layers.Core.Infrastructure.Base.Repositories;
using Lookif.Layers.Service.Services.Base;

namespace SimpleExpenseManagement.Service.Services.Loans
{
    public class LoanDetailService : BaseService<LoanDetail, Guid>, ILoanDetailService, IScopedDependency
    {
        private readonly IRepository<LoanDetail> _repository;

        public LoanDetailService(IRepository<LoanDetail> repository) : base(repository)
        {
            _repository = repository;
        }

    }
}
