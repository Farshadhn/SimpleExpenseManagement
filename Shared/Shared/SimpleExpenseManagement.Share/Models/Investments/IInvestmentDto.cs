using SimpleExpenseManagement.Constants.Enums;
using Lookif.Layers.Core.MainCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.Share.Models.Investments
{
    public interface IInvestmentDto : IEntity, IActive
    {

        public Guid AccountId { get; set; }

        public decimal FromAmount { get; set; }
   
        public Guid FromUnitId { get; set; }

        public decimal ToAmount { get; set; }
     
        public Guid ToUnitId { get; set; }

        public string Address { get; set; }
        public DateTime DateTime { get; set; }

        public TypeOfOperation TypeOfOperation { get; set; }

    }
}
