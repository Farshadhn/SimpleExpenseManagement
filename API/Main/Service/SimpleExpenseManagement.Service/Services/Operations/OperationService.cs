using SimpleExpenseManagement.Core.Infrastructure.Operations;
using SimpleExpenseManagement.Core.Infrastructure.Tags;
using SimpleExpenseManagement.Core.Models.Operations;
using SimpleExpenseManagement.Core.Models.Tags;
using Lookif.Layers.Core.Infrastructure.Base;
using Lookif.Layers.Core.Infrastructure.Base.Repositories;
using Lookif.Layers.Service.Services.Base;

namespace SimpleExpenseManagement.Service.Services.Operations;

public class OperationService : BaseService<Operation, Guid>, IOperationService, IScopedDependency
{
    private readonly IRepository<Operation> _repository; 

    public OperationService(IRepository<Operation> repository ) : base(repository)
    {
        _repository = repository; 

    }

    

}
