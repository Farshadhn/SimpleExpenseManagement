using SimpleExpenseManagement.Core.Infrastructure.Tags;
using SimpleExpenseManagement.Core.Models.Tags;
using Lookif.Layers.Core.Infrastructure.Base;
using Lookif.Layers.Core.Infrastructure.Base.Repositories;
using Lookif.Layers.Service.Services.Base;

namespace SimpleExpenseManagement.Service.Services.Tags
{
    public class Operation_TagService : BaseService<Operation_Tag, Guid>, IOperation_TagService, IScopedDependency
    {
        public Operation_TagService(IRepository<Operation_Tag> repository) : base(repository)
        {
        }
    }
}
