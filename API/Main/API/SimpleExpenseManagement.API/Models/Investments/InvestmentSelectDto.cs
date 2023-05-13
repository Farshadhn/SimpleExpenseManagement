using SimpleExpenseManagement.Constants.Enums;
using SimpleExpenseManagement.Core.Models.Investments;
using SimpleExpenseManagement.Share.Models.Investments;
using Lookif.Layers.WebFramework.Api;

namespace SimpleExpenseManagement.API.Models.Investments
{
    public class InvestmentSelectDto : BaseDto<InvestmentSelectDto, Investment, Guid>, IInvestmentSelectDto
    {
        public Guid AccountId { get; set; }
        public string AccountTitle { get; set; }

        public decimal FromAmount { get; set; }

        public Guid FromUnitId { get; set; }
        public string FromUnitTitle { get; set; }

        public decimal ToAmount { get; set; }

        public Guid ToUnitId { get; set; }
        public string ToUnitTitle { get; set; }

        public string Address { get; set; }
        public DateTime DateTime { get; set; }

        public TypeOfOperation TypeOfOperation { get; set; }
        public bool IsActive { get; set; }
    }
}
