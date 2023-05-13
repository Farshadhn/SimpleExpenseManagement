using SimpleExpenseManagement.Core.Models.Tags;
using SimpleExpenseManagement.Share.Models.Tags.Operation_Tags;
using Lookif.Layers.WebFramework.Api;

namespace SimpleExpenseManagement.API.Models.Tags.Operation_Tags
{
    public class Operation_TagSelectDto : BaseDto<Operation_TagSelectDto, Operation_Tag, Guid>, IOperation_TagSelectDto
    {
        public Guid OperationId { get; set; }
        public string OperationDefinition { get; set; }
        public Guid TagId { get; set; }
        public string TagTitle { get; set; }
        public bool IsActive { get; set; }
    }
}
