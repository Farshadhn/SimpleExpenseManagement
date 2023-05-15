using SimpleExpenseManagement.Core.Infrastructure.Tags;
using SimpleExpenseManagement.Core.Models.Tags;
using Lookif.Layers.Core.Infrastructure.Base;
using Lookif.Layers.Core.Infrastructure.Base.Repositories;
using Lookif.Layers.Service.Services.Base;

namespace SimpleExpenseManagement.Service.Services.Tags;

public class TagService : BaseService<Tag, Guid>, ITagService, IScopedDependency
{
    private readonly IRepository<Tag> _repository; 

    public TagService(IRepository<Tag> repository ) : base(repository)
    {
        _repository = repository; 
    }

    

}
