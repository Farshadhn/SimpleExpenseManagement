
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

        public string tags { get; set; }

        public List<Guid> TagList { get; set; }
        public Guid? EventId { get ; set ; }
        public Guid? UserId { get; set; }
    }
}
