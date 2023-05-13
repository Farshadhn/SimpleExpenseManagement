using Lookif.Layers.Core.MainCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.Share.Models.Loans.LoanDetails
{
    public interface ILoanDetailDto : IEntity, IActive
    {

        public Guid? OperationId { get; set; }
    

        public Guid LoanMasterId { get; set; }
   


        public decimal Amount { get; set; }
        public decimal Paid { get; set; }
        public DateTime DueTime { get; set; }
        public DateTime? PaidDateTime { get; set; }

    }
}
