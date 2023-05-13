using SimpleExpenseManagement.API.Models.Loans.LoanDetails;
using SimpleExpenseManagement.Core.Models.Loans;
using SimpleExpenseManagement.Share.Models.Loans.LoanMasters;
using Lookif.Layers.WebFramework.Api;

namespace SimpleExpenseManagement.API.Models.Loans.LoanMasters
{
    public class LoanMasterDto : BaseDto<LoanMasterDto, LoanMaster, Guid>, ILoanMasterDto
    {
        public int Count { get; set; }
        public int InterestRate { get; set; }
        public string Title { get; set; }
        public string Definition { get; set; }
        public decimal Freeze { get; set; }
        public Guid? OperationId { get; set; }
       
        public bool IsActive { get; set; }
        public List<LoanDetailDto> LoanDetails { get; set; }
    }
}
