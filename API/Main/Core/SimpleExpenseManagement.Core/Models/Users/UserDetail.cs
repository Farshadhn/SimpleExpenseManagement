using SimpleExpenseManagement.Core.Models.Accounts;
using Lookif.Layers.Core.MainCore.Base;
using Lookif.Layers.Core.MainCore.Identities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleExpenseManagement.Core.Models.Users;

public class UserDetail : BaseEntity<Guid>, IActive
{
    [ForeignKey(nameof(UserId))]
    public Guid UserId { get; set; }
    public User User { get; set; }

    public virtual ICollection<Account> Accounts { get; set; }
    public bool IsActive { get ; set ; }
}
