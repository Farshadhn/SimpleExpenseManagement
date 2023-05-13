using SimpleExpenseManagement.Core.Infrastructure.Tags;
using SimpleExpenseManagement.Core.Models.Tags;
using Lookif.Layers.Core.Infrastructure.Base;
using Lookif.Layers.Core.Infrastructure.Base.Repositories;
using Lookif.Layers.Service.Services.Base;

namespace SimpleExpenseManagement.Service.Services.Tags
{
    public class TagService : BaseService<Tag, Guid>, ITagService, IScopedDependency
    {
        private readonly IRepository<Tag> _repository;
        private readonly IOperation_TagService _operation_TagService;

        public TagService(IRepository<Tag> repository, IOperation_TagService operation_TagService) : base(repository)
        {
            _repository = repository;
            _operation_TagService = operation_TagService;
        }

        public async Task<Tag> AddTag(Tag tg, List<Guid> Operationlist, CancellationToken cancellationToken)
        {
            var tag = await base.AddAsync(tg, cancellationToken);
            if (Operationlist is not null && Operationlist.Any())
                await _operation_TagService.AddRangeAsync(
                    Operationlist.ConvertAll(x => new Operation_Tag() { OperationId = x, TagId = tg.Id }), cancellationToken);
            return tag;
        }

    }
}
