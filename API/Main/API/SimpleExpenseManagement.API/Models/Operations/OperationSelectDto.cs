
using SimpleExpenseManagement.Constants.Enums;
using SimpleExpenseManagement.Core.Models.Operations;
using SimpleExpenseManagement.Share.Models.Operations;
using Lookif.Layers.WebFramework.Api;

namespace SimpleExpenseManagement.API.Models.Operations
{
    public class OperationSelectDto : BaseDto<OperationSelectDto, Operation, Guid>, IOperationSelectDto
    {
        public Guid? FromId { get; set; }
        public string FromTitle { get; set; }
        public Guid? ToId { get; set; }
        public string ToTitle { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Amount { get; set; }
        public TypeOfOperation TypeOfOperation { get; set; }
        public string Definition { get; set; }
        public bool IsActive { get; set; }
         
        public string TagTitle { get; set; }
        public Guid? TagId { get; set; }
        public Guid? UserId { get; set; }
    }
}
