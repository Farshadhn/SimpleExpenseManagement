using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.UI.Models.Authentication
{
    public class AuthenticatedUserModel
    {
        public string access_token { get; set; }
        public string UserName { get; set; }
        public bool IsSuccess{ get; set; }
        public string Error { get; set; }
        public string Email { get; set; }

    }

}
