using SimpleExpenseManagement.Core.Models.Loans;
using SimpleExpenseManagement.Share.Models.Loans.LoanDetails;
using Lookif.Layers.WebFramework.Api;

namespace SimpleExpenseManagement.API.Models.Loans.LoanDetails
{
    public class LoanDetailSelectDto : BaseDto<LoanDetailSelectDto, LoanDetail, Guid>, ILoanDetailSelectDto
    {
        public Guid? OperationId { get; set; }
        public Guid LoanMasterId { get; set; }
        public decimal Amount { get; set; }
        public decimal Paid { get; set; }
        public DateTime DueTime { get; set; }
        public DateTime? PaidDateTime { get; set; }
        public bool IsActive { get; set; }
        public string OperationDefinition { get ; set ; }
        public string LoanMasterTitle { get ; set ; }
    }
}
