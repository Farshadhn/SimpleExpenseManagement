using SimpleExpenseManagement.Share.Models.Loans.LoanMasters;
using Lookif.Layers.Core.MainCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.UI.Models.Loans.LoanMasters
{
    public class LoanMasterSelectDto :  LoanMasterDto , ILoanMasterSelectDto
    {
        public string OperationDefinition { get; set; }
    }
}
