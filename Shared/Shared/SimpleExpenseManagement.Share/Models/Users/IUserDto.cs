using Lookif.Layers.Core.Enums;
using Lookif.Layers.Core.MainCore.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleExpenseManagement.Share.Users;

        /// <summary>
/// Main User Entity 
/// </summary>
public interface IUserDto : IEntity, IActive
{
    //  [MaxFileSize(5 * 1024 * 1024)]
    //  [AllowedExtensions(new string[] { ".jpg", ".png" })]
    //  public IFormFile Image { get; set; }

    [StringLength(50)]
    public string ImagePath { get; set; }

    /// <summary>
    /// UserName of this entity
    /// </summary>
    //[Required]
    [StringLength(100)]
    public string UserName { get; set; }
    /// <summary>
    /// Email(*@*.*)
    /// </summary>
    [Required]
    [StringLength(100)]
    public string Email { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string NormalizedEmail => Email.ToUpper();
    /// <summary>
    /// Password that has to be complex
    /// </summary>
    //[Required]
    [StringLength(500)]
    public string PasswordHash { get; set; }
    public string NewPassword { get; set; }
    /// <summary>
    /// Fullname
    /// </summary>
    [Required]
    [StringLength(100000000)]
    public string FullName { get; set; }

    /// <summary>
    /// Age
    /// </summary>
    public int Age { get; set; }
    /// <summary>
    /// Male or female
    /// </summary>
    public GenderType Gender { get; set; }


    /// <summary>
    /// More Detail about ME!
    /// </summary>
    public string Description { get; set; }


    /// <summary>
    /// Is he admin or not
    /// </summary>
    public bool IsInRole { get; set; }

}
