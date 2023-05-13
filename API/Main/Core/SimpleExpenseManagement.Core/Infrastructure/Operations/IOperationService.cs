using SimpleExpenseManagement.Core.Models.Operations;
using Lookif.Layers.Core.Infrastructure.Base;

namespace SimpleExpenseManagement.Core.Infrastructure.Operations;

public interface IOperationService : IBaseService<Operation, Guid>, IScopedDependency
{
    Task<Operation> AddOperation(Operation op, List<Guid> tags, CancellationToken cancellationToken);
    Task<Operation> UpdateOperation_Tag(Operation t, List<Guid> TagIds, CancellationToken cancellationToken);
    Task DeleteOperation_Tag(Guid id, CancellationToken cancellationToken);
}