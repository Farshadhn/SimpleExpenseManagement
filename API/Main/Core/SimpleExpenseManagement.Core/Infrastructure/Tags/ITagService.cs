using SimpleExpenseManagement.Core.Models.Tags;
using Lookif.Layers.Core.Infrastructure.Base;

namespace SimpleExpenseManagement.Core.Infrastructure.Tags
{
    public interface ITagService : IBaseService<Tag, Guid>, IScopedDependency
    {
        Task<Tag> AddTag(Tag tg, List<Guid> Operationlist, CancellationToken cancellationToken);
    }
}
