using SimpleExpenseManagement.Share.Models.Loans.LoanDetails;
using SimpleExpenseManagement.UI.Models.Loans.LoanMasters;
using SimpleExpenseManagement.UI.Models.Operations;
using Lookif.UI.Component.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SimpleExpenseManagement.UI.Models.Loans.LoanDetails
{
    public class LoanDetailDto : BaseDto, ILoanDetailDto
    {

        [RelatedTo(nameof(OperationDto), "Definition")]
        [Hidden]
        public Guid? OperationId { get; set; }
        [RelatedTo(nameof(LoanMasterDto), "Title")]
        [Hidden]
        public Guid LoanMasterId { get; set; }
        public decimal Amount { get; set; }
        public decimal Paid { get; set; }
        public DateTime DueTime { get; set; }
        public DateTime? PaidDateTime { get; set; }


     
        [HiddenDto(HiddenStatus.Create)]
        public bool IsActive { get; set; }


    }
}
