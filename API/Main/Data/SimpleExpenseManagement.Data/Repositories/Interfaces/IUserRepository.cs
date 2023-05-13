using Lookif.Layers.Core.Infrastructure.Base.Repositories;
using Lookif.Layers.Core.MainCore.Identities;

namespace SimpleExpenseManagement.Data.Repositories.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByUserAndPass(string username, string password, CancellationToken cancellationToken);

    Task AddAsync(User user, string password, CancellationToken cancellationToken);
    Task UpdateSecuirtyStampAsync(User user, CancellationToken cancellationToken);
    Task UpdateLastLoginDateAsync(User user, CancellationToken cancellationToken);
}

