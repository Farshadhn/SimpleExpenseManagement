using SimpleExpenseManagement.Constants.Enums;
using SimpleExpenseManagement.Core.Models.Investments;
using SimpleExpenseManagement.Share.Models.Investments;
using Lookif.Layers.WebFramework.Api;

namespace SimpleExpenseManagement.API.Models.Investments
{
    public class InvestmentDto : BaseDto<InvestmentDto, Investment, Guid>, IInvestmentDto
    {
        public Guid AccountId { get; set; }

        public decimal FromAmount { get; set; }

        public Guid FromUnitId { get; set; }

        public decimal ToAmount { get; set; }

        public Guid ToUnitId { get; set; }

        public string Address { get; set; }
        public DateTime DateTime { get; set; }

        public TypeOfOperation TypeOfOperation { get; set; }
        public bool IsActive { get; set; }
    }
}
