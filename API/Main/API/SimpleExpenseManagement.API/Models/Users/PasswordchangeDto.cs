using SimpleExpenseManagement.Share.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleExpenseManagement.API.Models.Users;

public class PasswordchangeDto : IPasswordchangeDto
{
    public string OldPass {get;set;}
    public string NewPassword {get;set;}
    public string UserName {get;set;}
    public string Email {get;set;}
    public int UserId {get;set;}
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
}
