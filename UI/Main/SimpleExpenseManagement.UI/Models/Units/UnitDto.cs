using SimpleExpenseManagement.Share.Models.Units;
using Lookif.Layers.Core.MainCore.Base;
using Lookif.UI.Component.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.UI.Models.Units
{
    public class UnitDto : BaseDto, IUnitDto
    {
        [Display(Name = "Quantity Required")]
        public string Title { get; set; }
        [Hidden]
        [HiddenDto(HiddenStatus.Create)]
        public bool IsActive { get; set; }

 
    }
}
