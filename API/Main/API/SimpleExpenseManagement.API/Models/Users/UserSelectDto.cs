﻿
using SimpleExpenseManagement.Share.Models.Users;
using Lookif.Layers.Core.Enums;
using Lookif.Layers.Core.MainCore.Identities;
using Lookif.Layers.WebFramework.Api;

namespace SimpleExpenseManagement.API.Models.Users
{
    public class UserSelectDto : BaseDto<UserSelectDto, User, Guid>, IUserSelectDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public GenderType Gender { get; set; }
        public string Description { get; set; }
        public bool IsInRole { get; set; }
        public bool Block { get; set; }
        public bool IsActive { get; set; }

    }
}
