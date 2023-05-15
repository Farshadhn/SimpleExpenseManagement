using SimpleExpenseManagement.Core.Models.Tags;
using Lookif.Layers.Core.Infrastructure.Base;

namespace SimpleExpenseManagement.Core.Infrastructure.Tags
{
    public interface ITagService : IBaseService<Tag, Guid>, IScopedDependency
    {
        
    }
}
