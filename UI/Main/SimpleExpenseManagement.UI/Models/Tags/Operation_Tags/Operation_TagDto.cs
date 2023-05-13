using SimpleExpenseManagement.Share.Models.Tags.Operation_Tags;
using SimpleExpenseManagement.UI.Models.Operations;
using Lookif.Layers.Core.MainCore.Base;
using Lookif.UI.Component.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SimpleExpenseManagement.UI.Models.Tags.Operation_Tags
{
    public class Operation_TagDto : BaseDto, IOperation_TagDto
    {
        [RelatedTo(nameof(OperationDto), "Definition")]
        [Hidden]
        public Guid OperationId { get; set; }
        [RelatedTo(nameof(TagDto), "Title")]
        [Hidden]
        public Guid TagId { get; set; }
      
        [HiddenDto(HiddenStatus.Create)]
        public bool IsActive { get; set; }



    }
}
