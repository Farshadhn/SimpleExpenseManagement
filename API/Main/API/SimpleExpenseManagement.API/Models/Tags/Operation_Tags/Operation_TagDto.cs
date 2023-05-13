using SimpleExpenseManagement.Core.Models.Tags;
using SimpleExpenseManagement.Share.Models.Tags.Operation_Tags;
using Lookif.Layers.WebFramework.Api;

namespace SimpleExpenseManagement.API.Models.Tags.Operation_Tags
{
    public class Operation_TagDto : BaseDto<Operation_TagDto, Operation_Tag, Guid>, IOperation_TagDto
    {
        public Guid OperationId { get; set; }
        public Guid TagId { get; set; }
        public bool IsActive { get; set; }
    }
}
