using SimpleExpenseManagement.Core.Models.Loans;
using SimpleExpenseManagement.Share.Models.Loans.LoanMasters;
using Lookif.Layers.WebFramework.Api;

namespace SimpleExpenseManagement.API.Models.Loans.LoanMasters
{
    public class LoanMasterSelectDto : BaseDto<LoanMasterSelectDto, LoanMaster, Guid>, ILoanMasterSelectDto
    {
        public int Count { get; set; }
        public int InterestRate { get; set; }
        public string Title { get; set; }
        public string Definition { get; set; }
        public decimal Freeze { get; set; }
        public Guid? OperationId { get; set; }
        public string OperationDefinition { get; set; }

        public bool IsActive { get; set; }
    }
}
