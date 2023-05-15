using SimpleExpenseManagement.Constants.Enums;
using SimpleExpenseManagement.Share.Models.Accounts;
using Lookif.UI.Component.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SimpleExpenseManagement.UI.Models.Accounts;

public class AccountDto : BaseDto, IAccountDto
{
    public string Title { get; set; }
    public decimal InitialValue { get; set; }
    [HiddenDto]
    public decimal Value { get; set; }
    public AccountVisibilityStatus AccountVisibilityStatus { get; set; }
    [Hidden]
    [HiddenDto]
    public bool IsActive { get; set; }


}
