using SimpleExpenseManagement.Constants.Enums;
using SimpleExpenseManagement.Share.Models.Investments;
using SimpleExpenseManagement.UI.Models.Accounts;
using SimpleExpenseManagement.UI.Models.Units;
using Lookif.Layers.Core.MainCore.Base;
using Lookif.UI.Component.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.UI.Models.Investments
{
    public class InvestmentDto : BaseDto, IInvestmentDto
    {
        public decimal FromAmount { get; set; }
        [RelatedTo(nameof(AccountDto),"Title")]
        [Hidden]
        public Guid AccountId { get; set; }

       
        [RelatedTo(nameof(UnitDto), "Title")]
        [Hidden]
        public Guid FromUnitId { get; set; }

        public decimal ToAmount { get; set; }
        [RelatedTo(nameof(UnitDto), "Title")]
        [Hidden]
        public Guid ToUnitId { get; set; }

        public string Address { get; set; }
        public DateTime DateTime { get; set; }

        public TypeOfOperation TypeOfOperation { get; set; }
       
        [HiddenDto(HiddenStatus.Create)]
        public bool IsActive { get; set; }

 
      
    }
}
