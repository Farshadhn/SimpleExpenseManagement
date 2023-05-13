using SimpleExpenseManagement.Share.Models.Investments;

namespace SimpleExpenseManagement.UI.Models.Investments
{
    public class InvestmentSelectDto : InvestmentDto, IInvestmentSelectDto
    {
        public string AccountTitle { get; set; }
        public string FromUnitTitle { get; set; }
        public string ToUnitTitle { get; set; }
    }
}
