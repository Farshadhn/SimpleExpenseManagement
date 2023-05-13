using SimpleExpenseManagement.Core.Models.Events;
using SimpleExpenseManagement.Core.Models.Operations;
using SimpleExpenseManagement.Share.Models.Events;
using Lookif.Layers.WebFramework.Api;

namespace SimpleExpenseManagement.API.Models.Events
{
    public class EventDto : BaseDto<EventDto, Event, Guid>, IEventDto
    {

        //public string EventTitle { get; set; } = string.Empty;
        public string EventTitle { get; set; }
        public string EventDefinition { get; set; }

        public bool IsActive { get; set; }
    }
}