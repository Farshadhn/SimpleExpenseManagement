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
    private readonly IOperation_TagService _operation_TagService;

    public OperationService(IRepository<Operation> repository, IOperation_TagService operation_TagService) : base(repository)
    {
        _repository = repository;
        _operation_TagService = operation_TagService;

    }

    public async Task<Operation> AddOperation(Operation op, List<Guid> tags, CancellationToken cancellationToken)
    {
       
        var opration = await base.AddAsync(op, cancellationToken);

        if (tags is not null && tags.Any())
            await _operation_TagService.AddRangeAsync(
                tags.ConvertAll(x => new Operation_Tag() { TagId = x, OperationId = op.Id }), cancellationToken);
        return opration;
    }

    public async Task<Operation> UpdateOperation_Tag(Operation t, List<Guid> TagIds, CancellationToken cancellationToken)
    {
        await base.UpdateAsync(t, cancellationToken, true);
        var itemclasses = await _operation_TagService.GetAllByCondition(x => x.OperationId == t.Id, cancellationToken);
        foreach (var item in itemclasses)
        {
            await _operation_TagService.DeleteAsync(item, cancellationToken);

        }

        await _operation_TagService.AddRangeAsync(
            TagIds.ConvertAll(x => new Operation_Tag() { TagId = x, OperationId = t.Id }), cancellationToken);


        return t;
    }
    public async Task DeleteOperation_Tag(Guid id, CancellationToken cancellationToken)
    {

        var itemclasses = await _operation_TagService.GetAllByCondition(x => x.OperationId == id, cancellationToken);
        foreach (var item in itemclasses)
        {
            await _operation_TagService.DeleteAsync(item, cancellationToken);

        }

    }

}
