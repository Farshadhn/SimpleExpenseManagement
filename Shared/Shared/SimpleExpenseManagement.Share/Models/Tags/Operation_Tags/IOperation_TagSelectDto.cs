using Lookif.Layers.Core.MainCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.Share.Models.Tags.Operation_Tags
{
    public interface IOperation_TagSelectDto : IEntity , IOperation_TagDto
    {
        public string OperationDefinition { get; set; }
        public string TagTitle { get; set; }
    }
}
