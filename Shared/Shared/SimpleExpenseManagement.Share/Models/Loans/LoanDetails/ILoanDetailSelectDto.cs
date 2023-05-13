using Lookif.Layers.Core.MainCore.Base;

namespace SimpleExpenseManagement.Share.Models.Loans.LoanDetails
{
    public interface ILoanDetailSelectDto : IEntity, ILoanDetailDto
    {
        public string OperationDefinition { get; set; }
        public string LoanMasterTitle { get; set; }
    }
}
