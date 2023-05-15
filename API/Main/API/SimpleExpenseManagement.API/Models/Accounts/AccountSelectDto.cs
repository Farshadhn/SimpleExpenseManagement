using SimpleExpenseManagement.Constants.Enums;
using SimpleExpenseManagement.Core.Models.Accounts;
using SimpleExpenseManagement.Share.Models.Accounts;
using Lookif.Layers.WebFramework.Api;

namespace SimpleExpenseManagement.API.Models.Accounts;

public class AccountSelectDto : BaseDto<AccountSelectDto, Account, Guid>, IAccountSelectDto
{
    public decimal InitialValue { get; set; }
    public string Title { get; set ; }
    public decimal Value { get; set; }
    public AccountVisibilityStatus AccountVisibilityStatus { get; set ; }
    public bool IsActive { get; set ; }
 
}
