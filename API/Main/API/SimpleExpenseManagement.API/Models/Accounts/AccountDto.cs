using SimpleExpenseManagement.Constants.Enums;
using SimpleExpenseManagement.Core.Models.Accounts;
using SimpleExpenseManagement.Share.Models.Accounts;
using Lookif.Layers.WebFramework.Api;

namespace SimpleExpenseManagement.API.Models.Accounts
{
    public class AccountDto : BaseDto<AccountDto, Account, Guid>, IAccountDto
    {
        public decimal InitialValue { get; set ; }
        public string Title { get; set; }
        public AccountVisibilityStatus AccountVisibilityStatus { get; set; }
        public bool IsActive { get; set; }
    }
}
