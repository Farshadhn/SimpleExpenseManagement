using Lookif.Layers.Core.MainCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.Share.Models.Events
{
    public interface IEventDto : IEntity, IActive
    {
        public string EventTitle { get; set; }
        public string EventDefinition { get; set; }

    }
}
