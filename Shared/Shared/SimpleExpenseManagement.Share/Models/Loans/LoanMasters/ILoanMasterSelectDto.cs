﻿using Lookif.Layers.Core.MainCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.Share.Models.Loans.LoanMasters
{
    public interface ILoanMasterSelectDto : IEntity , ILoanMasterDto
    {
        public string OperationDefinition { get; set; }
    }
}
