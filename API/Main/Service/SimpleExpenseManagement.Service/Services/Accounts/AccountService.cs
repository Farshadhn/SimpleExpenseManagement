using SimpleExpenseManagement.Core.Infrastructure.Accounts;
using SimpleExpenseManagement.Core.Models.Accounts;
using Lookif.Layers.Core.Infrastructure.Base;
using Lookif.Layers.Core.Infrastructure.Base.Repositories;
using Lookif.Layers.Service.Services.Base;

namespace SimpleExpenseManagement.Service.Services.Accounts;

public class AccountService : BaseService<Account, Guid>, IAccountServicecs, IScopedDependency
{
    private readonly IRepository<Account> _repository;

    public AccountService(IRepository<Account> repository) : base(repository)
    {
        _repository = repository;
    }

}
