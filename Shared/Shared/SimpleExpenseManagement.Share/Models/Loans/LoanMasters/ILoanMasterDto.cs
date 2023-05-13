using Lookif.Layers.Core.MainCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.Share.Models.Loans.LoanMasters
{
    public interface ILoanMasterDto : IEntity, IActive
    {
        public int Count { get; set; }
       
        public int InterestRate { get; set; }
        public string Title { get; set; }
        public string Definition { get; set; }
        public decimal Freeze { get; set; }
  

        public Guid? OperationId { get; set; }
    
    }
}
