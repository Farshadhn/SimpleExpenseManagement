using Lookif.Layers.Core.MainCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.Share.Models.Units
{
    public interface IUnitDto : IEntity, IActive
    {
        public string Title { get; set; }
    }
}
