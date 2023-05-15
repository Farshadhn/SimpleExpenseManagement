﻿using Lookif.Layers.Core.MainCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.Share.Models.Tags
{
    public interface ITagDto : IEntity, IActive
    {
        public string Title { get; set; }
        public string Color { get; set; } 
    }
}
