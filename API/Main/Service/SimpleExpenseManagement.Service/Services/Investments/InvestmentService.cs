using SimpleExpenseManagement.Core.Infrastructure.Investments;
using SimpleExpenseManagement.Core.Models.Investments;
using Lookif.Layers.Core.Infrastructure.Base;
using Lookif.Layers.Core.Infrastructure.Base.Repositories;
using Lookif.Layers.Service.Services.Base;

namespace SimpleExpenseManagement.Service.Services.Investments
{
    public class InvestmentService : BaseService<Investment, Guid>, IInvestmentService, IScopedDependency
    {
        private readonly IRepository<Investment> _repository;

        public InvestmentService(IRepository<Investment> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
