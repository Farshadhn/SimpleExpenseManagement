using Lookif.Layers.Core.Infrastructure.Base;
using SimpleExpenseManagement.Core.Models.Users;

namespace SimpleExpenseManagement.Core.Infrastructure.Users;

public  interface IUserDetailService : IBaseService<UserDetail, Guid>, IScopedDependency
{
}
