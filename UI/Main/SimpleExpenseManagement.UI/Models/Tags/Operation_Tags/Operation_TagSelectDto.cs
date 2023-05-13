using SimpleExpenseManagement.Share.Models.Tags.Operation_Tags;
using SimpleExpenseManagement.UI.Models.Tags.Operation_Tags;
using Lookif.Layers.Core.MainCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.UI.Models.Tags.Operation_Tags
{
    public class Operation_TagSelectDto : Operation_TagDto, IOperation_TagSelectDto
    {
        public string OperationDefinition { get; set; }
        public string TagTitle { get; set; }
        public Guid OperationId { get; set; }
    }
}
