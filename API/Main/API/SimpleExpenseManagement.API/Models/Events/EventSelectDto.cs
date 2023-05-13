using SimpleExpenseManagement.Core.Models.Events;
using SimpleExpenseManagement.Share.Models.Events;
using Lookif.Layers.WebFramework.Api;

namespace SimpleExpenseManagement.API.Models.Events
{
    public class EventSelectDto : BaseDto<EventSelectDto, Event, Guid>, IEventSelectDto
    { 
        public string EventTitle { get; set; }
        public string EventDefinition { get; set; }
        public bool IsActive { get; set; }
    }
}
