using Lookif.Layers.Core.MainCore.Base;

namespace SimpleExpenseManagement.Share.Models.Tags.Operation_Tags
{
    public interface IOperation_TagDto : IEntity, IActive
    {
        public Guid OperationId { get; set; }
        public Guid TagId { get; set; }

    }
}
