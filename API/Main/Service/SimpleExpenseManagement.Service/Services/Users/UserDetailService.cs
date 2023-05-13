using Lookif.Layers.Core.Infrastructure.Base;
using Lookif.Layers.Core.Infrastructure.Base.Repositories;
using Lookif.Layers.Service.Services.Base;
using SimpleExpenseManagement.Core.Infrastructure.Users;
using SimpleExpenseManagement.Core.Models.Users;

namespace SimpleExpenseManagement.Service.Services.Users
{
  public  class UserDetailService : BaseService<UserDetail, Guid>, IUserDetailService, IScopedDependency
    {
        private readonly IRepository<UserDetail> _repository;
        public UserDetailService(IRepository<UserDetail> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
