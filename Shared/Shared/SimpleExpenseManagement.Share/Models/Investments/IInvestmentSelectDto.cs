using Lookif.Layers.Core.MainCore.Base;

namespace SimpleExpenseManagement.Share.Models.Investments
{
    public interface IInvestmentSelectDto : IEntity, IInvestmentDto
    {
        public string AccountTitle { get; set; }
        public string FromUnitTitle { get; set; }
        public string ToUnitTitle { get; set; }

    }
}
