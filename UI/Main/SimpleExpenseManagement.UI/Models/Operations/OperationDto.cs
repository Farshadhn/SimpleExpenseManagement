using SimpleExpenseManagement.Constants.Enums;
using SimpleExpenseManagement.Share.Models.Operations;
using SimpleExpenseManagement.UI.Models.Accounts;
using SimpleExpenseManagement.UI.Models.Tags;
using Lookif.UI.Component.Attributes;

namespace SimpleExpenseManagement.UI.Models.Operations;

public class OperationDto : BaseDto, IOperationDto
{
    [RelatedTo(nameof(AccountDto), "Title")]
    [Hidden]
    public Guid? FromId { get; set; }
    [RelatedTo(nameof(AccountDto), "Title")]
    [Hidden]
    public Guid? ToId { get; set; }
    public DateTime DateTime { get; set; }
    public decimal Amount { get; set; }
    public TypeOfOperation TypeOfOperation { get; set; }
    public string Definition { get; set; }


    [RelatedTo(nameof(TagDto), "Title")]
    [Hidden]
    public Guid? TagId { get; set; }
    [Hidden]
    [HiddenDto(HiddenStatus.Create)]
    public bool IsActive { get; set; }
    [Hidden]
    [HiddenDto(HiddenStatus.EditAndCreate)]
    public Guid? UserId { get; set; }
}
