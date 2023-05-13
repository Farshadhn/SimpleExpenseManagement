using Lookif.Layers.Core.MainCore.Base;

namespace SimpleExpenseManagement.Share.Models.Accounts
{
    public interface IAccountVisibilityDto : IEntity, IActive
    {
        public Guid AccountId { get; set; }
        public Guid UserId { get; set; }
    }
}
