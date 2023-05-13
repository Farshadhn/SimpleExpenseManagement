using SimpleExpenseManagement.Constants.Enums;
using Lookif.Layers.Core.MainCore.Base;

namespace SimpleExpenseManagement.Share.Models.Operations
{
    public interface IOperationDto : IEntity, IActive
    {
        public Guid? FromId { get; set; }
        public Guid? ToId { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Amount { get; set; }
        public TypeOfOperation TypeOfOperation { get; set; }
        public string Definition { get; set; }
        public Guid? EventId { get; set; }
        public List<Guid> TagList { get; set; }
        public Guid? UserId { get; set; }

    }
}
