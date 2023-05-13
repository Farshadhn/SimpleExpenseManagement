using SimpleExpenseManagement.Share.Models.Loans.LoanDetails;
using Lookif.Layers.Core.MainCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.UI.Models.Loans.LoanDetails
{
    public  class LoanDetailSelectDto : LoanDetailDto , ILoanDetailSelectDto
    {
        public string OperationDefinition { get; set; }
        public string LoanMasterTitle { get; set; }
    }
}
