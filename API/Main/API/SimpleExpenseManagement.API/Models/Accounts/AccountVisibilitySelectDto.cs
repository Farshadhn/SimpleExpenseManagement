using SimpleExpenseManagement.Core.Models.Accounts;
using SimpleExpenseManagement.Share.Models.Accounts;
using Lookif.Layers.WebFramework.Api;

namespace SimpleExpenseManagement.API.Models.Accounts;

public class AccountVisibilitySelectDto : BaseDto<AccountVisibilitySelectDto, AccountVisibility, Guid>, IAccountVisibilitySelectDto
{
    public Guid AccountId { get; set; }
    public string AccountTitle { get; set; }
    public Guid UserId { get; set; }
    public string UserFullName { get; set; }
    public bool IsActive { get; set; }
}
