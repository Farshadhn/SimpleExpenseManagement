using SimpleExpenseManagement.Core.Infrastructure.Accounts;
using SimpleExpenseManagement.Core.Models.Accounts;
using Lookif.Layers.Core.Infrastructure.Base;
using Lookif.Layers.Core.Infrastructure.Base.Repositories;
using Lookif.Layers.Service.Services.Base;

namespace SimpleExpenseManagement.Service.Services.Accounts;

public class AccountVisibilityService : BaseService<AccountVisibility, Guid>, IAccountVisibilityService, IScopedDependency
{
    private readonly IRepository<AccountVisibility> _repository;

    public AccountVisibilityService(IRepository<AccountVisibility> repository) : base(repository)
    {
        _repository = repository;
    }

}
