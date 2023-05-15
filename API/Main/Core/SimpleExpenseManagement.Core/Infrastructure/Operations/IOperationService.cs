using SimpleExpenseManagement.Core.Models.Operations;
using Lookif.Layers.Core.Infrastructure.Base;

namespace SimpleExpenseManagement.Core.Infrastructure.Operations;

public interface IOperationService : IBaseService<Operation, Guid>, IScopedDependency
{
 
}