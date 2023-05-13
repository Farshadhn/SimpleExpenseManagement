using Lookif.Layers.Core.MainCore.Base;
using Lookif.Layers.Core.MainCore.Identities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleExpenseManagement.Core.Models.Accounts;

public class AccountVisibility : BaseEntity<Guid>, IActive
{
    public Guid AccountId { get; set; }
    [ForeignKey(nameof(AccountId))]
    public Account Account { get; set; }



    public Guid UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    public bool IsActive { get ; set; }
}
