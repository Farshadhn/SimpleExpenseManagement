using SimpleExpenseManagement.Constants.Enums;
using SimpleExpenseManagement.Core.Models.Operations;
using SimpleExpenseManagement.Share.Models.Operations;
using Lookif.Layers.WebFramework.Api;

namespace SimpleExpenseManagement.API.Models.Operations
{
    public class OperationDto : BaseDto<OperationDto, Operation, Guid>, IOperationDto
    {

        public Guid? FromId { get; set; }
        public Guid? ToId { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Amount { get; set; }
        public TypeOfOperation TypeOfOperation { get; set; }
        public string Definition { get; set; }
        public Guid? EventId { get; set; }

        public List<Guid> TagList { get; set; }
        public bool IsActive { get; set; }

        public Guid? UserId { get; set; }
        
    }
}
