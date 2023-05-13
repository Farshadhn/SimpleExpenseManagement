using SimpleExpenseManagement.Constants.Enums;
using Lookif.Layers.Core.MainCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.Share.Models.Accounts
{
    public interface IAccountDto : IEntity, IActive
    {
        public decimal InitialValue { get; set; }
        public string Title { get; set; }
        public AccountVisibilityStatus AccountVisibilityStatus { get; set; }
    }
}
