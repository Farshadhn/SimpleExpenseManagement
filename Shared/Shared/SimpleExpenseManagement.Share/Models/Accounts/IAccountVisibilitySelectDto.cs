using Lookif.Layers.Core.MainCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.Share.Models.Accounts;

public interface IAccountVisibilitySelectDto : IEntity , IAccountVisibilityDto
{
    public string AccountTitle { get; set; }
    public string UserFullName { get; set; }

}
