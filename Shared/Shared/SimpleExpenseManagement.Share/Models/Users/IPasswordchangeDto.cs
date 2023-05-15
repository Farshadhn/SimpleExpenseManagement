using Lookif.Layers.Core.MainCore.Base;
using System;

namespace SimpleExpenseManagement.Share.Models.Users;

/// <summary>
/// 
/// </summary>
public interface IPasswordchangeDto: IActive
{
    /// <summary>
    /// 
    /// </summary>
    public string OldPass { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string NewPassword { get; set; }

    /// <summary>
    /// used for reset 
    /// </summary>
    public string UserName { get; set; }
    /// <summary>
    /// used for reset 
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// used for reset(Admin) 
    /// </summary>
    public int UserId { get; set; }
}
