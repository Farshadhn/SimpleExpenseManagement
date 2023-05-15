using SimpleExpenseManagement.Share.Models.Tags;
using SimpleExpenseManagement.UI.Models.Operations;
using Lookif.Layers.Core.MainCore.Base;
using Lookif.UI.Component.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.UI.Models.Tags;

public class TagDto : BaseDto, ITagDto
{
    public string Title { get; set; }
    public string Color { get; set; }


    //[RelatedTo(nameof(OperationDto), "Definition")]
    //public List<Guid> oprationList { get; set; }
    [Hidden]
    [HiddenDto(HiddenStatus.Create)]
    public bool IsActive { get; set; }

}
