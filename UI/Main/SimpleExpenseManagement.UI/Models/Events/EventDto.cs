using SimpleExpenseManagement.Share.Models.Events;
using Lookif.Layers.Core.MainCore.Base;
using Lookif.UI.Component.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.UI.Models.Events
{
    public class EventDto : BaseDto, IEventDto
    {

        [Display(Name = "Quantity Required")]
        public string EventTitle { get; set; }
       
        public string EventDefinition { get; set; }

        [Hidden]
        [HiddenDto(HiddenStatus.Create)]
        public bool IsActive { get; set; }


    }
}
