using SimpleExpenseManagement.Share.Models.Loans.LoanMasters;
using SimpleExpenseManagement.UI.Models.Operations;
using Lookif.Layers.Core.MainCore.Base;
using Lookif.UI.Component.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.UI.Models.Loans.LoanMasters
{
    public class LoanMasterDto : BaseDto , ILoanMasterDto
    {
        public string Title { get; set; }
        public int Count { get; set; }

        [Appearance(4,4,8)]
        public int InterestRate { get; set; }
     
        public string Definition { get; set; }


        [Appearance(4, 9, 3)]
        public decimal Freeze { get; set; }

        [Appearance(4, 4, 8)]
        [RelatedTo(nameof(OperationDto), "Definition")]
        [Hidden]
        public Guid? OperationId { get; set; }
   
        [HiddenDto(HiddenStatus.Create)]
        public bool IsActive { get; set; }

    }
}
