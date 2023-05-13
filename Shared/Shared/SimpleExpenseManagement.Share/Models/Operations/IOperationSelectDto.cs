﻿using Lookif.Layers.Core.MainCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.Share.Models.Operations
{
    public interface IOperationSelectDto : IEntity, IOperationDto
    {
        public string tags { get; set; }
    }
}
