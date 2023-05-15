using Lookif.Layers.Core.Enums;
using Lookif.Layers.Core.MainCore.Identities;
using Lookif.Library.Common.Utilities;
using SimpleExpenseManagement.Share.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SimpleExpenseManagement.UI.Models.Accounts;
using Lookif.UI.Component.Attributes;

namespace SimpleExpenseManagement.UI.Models.Users;

public class UserDto : BaseDto, IUserDto
{

    //  public IFormFile Image { get; set; }  
    public string ImagePath { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string NewPassword { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }
    public GenderType Gender { get; set; }
    public string Description { get; set; }
    public bool IsInRole { get; set; }
    public bool IsActive { get; set; }
    [RelatedTo(nameof(AccountDto), "Title")]
    [Hidden]
    public List<AccountDto> Accounts { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!Email.IsValidEmail())
            yield return new ValidationResult("ایمیل وارد شده صحیح نمی باشد");
    }
    //public async Task<int> SaveFiles(CancellationToken cancellationToken, string Add = "")
    //{
    //    if (!(Image is null))
    //        ImagePath = await Image.SaveTo(cancellationToken, Add);
    //    else
    //        ImagePath = null;

    //    return 1;
    //}



}
