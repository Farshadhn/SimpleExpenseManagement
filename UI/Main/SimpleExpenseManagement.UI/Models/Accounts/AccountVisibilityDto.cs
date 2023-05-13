using SimpleExpenseManagement.Share.Models.Accounts;
using SimpleExpenseManagement.UI.Models.Users;
using Lookif.UI.Component.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SimpleExpenseManagement.UI.Models.Accounts
{
    public class AccountVisibilityDto : BaseDto, IAccountVisibilityDto
    {
        [RelatedTo(nameof(AccountDto), "Title")]
        public Guid AccountId { get; set; }
        [RelatedTo(nameof(UserDto), "UserName")]
        public Guid UserId { get; set; }
        [Hidden]
        [HiddenDto(HiddenStatus.Create)]
        public bool IsActive { get; set; }

    }
}
