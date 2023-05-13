using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.UI.Models.Authentication
{
    public class AuthenticationUserModel : IValidatableObject
    {
        [Required(ErrorMessage = "No UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "No Password")]
        public string Password { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			throw new NotImplementedException();
		}
	}
}
