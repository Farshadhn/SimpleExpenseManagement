using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.UI.Models.Authentication
{
	public class PassRecoveryUserModel
	{
		[Required(ErrorMessage = "No UserName")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "No Email")]
		public string Email { get; set; }

	}
}
