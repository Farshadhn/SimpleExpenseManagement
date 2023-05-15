using SimpleExpenseManagement.Share.Models.Operations;

namespace SimpleExpenseManagement.UI.Models.Operations;

public class OperationSelectDto : OperationDto, IOperationSelectDto
{
    public string FromTitle { get; set; }
    public string ToTitle { get; set; }
    public string TagTitle { get; set; }
}
