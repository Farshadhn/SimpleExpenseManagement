using SimpleExpenseManagement.Share.Models.Accounts;

namespace SimpleExpenseManagement.UI.Models.Accounts
{
    public class AccountVisibilitySelectDto : AccountVisibilityDto, IAccountVisibilitySelectDto
    {
        public string AccountTitle { get; set; }
        public string UserFullName { get; set; }

    }
}
