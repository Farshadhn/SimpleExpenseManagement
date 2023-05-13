using AutoMapper;
using Lookif.Layers.Core.Else.JWT;
using Lookif.Layers.Core.MainCore.Identities;
using Lookif.Layers.WebFramework.Api;
using Lookif.Library.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SimpleExpenseManagement.Core.Infrastructure.Users;
using SimpleExpenseManagement.API.Models.Users;
using SimpleExpenseManagement.API.Models.JWT;
using SimpleExpenseManagement.Core.Models.Users;
using SimpleExpenseManagement.Core.Models.Accounts;

namespace SimpleExpenseManagement.API.Controllers.v1.Users;

/// <summary>
/// This Controller is used to manage user's operations
/// </summary>
/// 
[ApiVersion("1")]
public class UserController : CrudController<UserDto, UserSelectDto, User, IUserService>
{
    private readonly IMapper _mapper;
    private readonly RoleManager<Role> roleManager; 
    private readonly UserManager<User> userManager; 
    private readonly SiteSettings _siteSetting;
    private readonly IUserDetailService UserDetailService;


    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="roleManager"></param>
    /// <param name="userManager"></param>
    /// <param name="settings"></param>
    /// <param name="logger"></param>
    public UserController(IMapper mapper,
                           RoleManager<Role> roleManager,
                           UserManager<User> userManager,
                           IOptionsSnapshot<SiteSettings> settings,
                           ILogger<UserController> logger, IUserDetailService UserDetailService
                           ) : base(mapper)
    {
        this._mapper = mapper;
        this.roleManager = roleManager;
        this.userManager = userManager; 
        this.UserDetailService = UserDetailService;
        _siteSetting = settings.Value;
    }


    [AllowAnonymous]
    [HttpGet]
    public override async Task<ApiResult<List<UserSelectDto>>> Get(CancellationToken cancellationToken)
    {

        var res = await base.Get(cancellationToken);
        
        return res;
    }



    /// <summary>
    /// Get user by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet("{id}")]
    public override async Task<ApiResult<UserSelectDto>> Get(Guid id, CancellationToken cancellationToken) //User Select has to be changed to detail one
    {
        var user = await Service.GetByIdAsync(id, cancellationToken);
        var rolesAsync = await userManager.GetRolesAsync(user);
        user.ImagePath = (user.ImagePath is null) ? "" : $"{_siteSetting.WebImageSource}\\{user.ImagePath}";

        user.IsInRole = rolesAsync.Contains("Admin");
        var ResUser = _mapper.Map<UserSelectDto>(user);

        
        return ResUser;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Authorize(Roles = "SuperAdmin")]
    [HttpGet]
    public async Task<ApiResult<List<UserSelectDto>>> GetAdmins(CancellationToken cancellationToken) //User Select has to be changed to detail one
    {
        var allUsers = await Service.GetAll().ToListAsync(cancellationToken);
        var legibleUsers = new List<UserSelectDto>();
        foreach (var user in allUsers)
        {
            var rolesAsync = await userManager.GetRolesAsync(user);
            if (rolesAsync.Contains("Admin"))
                legibleUsers.Add(_mapper.Map<UserSelectDto>(user));
        }
        return legibleUsers;


    }


    /// <summary>
    ///  this is used for UI to get User id from backend 
    /// </summary>
    /// <returns></returns>
    [Authorize]
    [HttpGet]
    public Guid GetMyId() //User Select has to be changed to detail one
    {
        return UserId;

    }



    /// <summary>
    /// User Dashboard - To See his information
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Authorize]
    [HttpGet]
    public async Task<ApiResult<UserSelectDto>> GetMyAcc(CancellationToken cancellationToken)
    =>
        await this.Get(UserId, cancellationToken);



    #region ...Vue usage ...
    /// <summary>
    ///  this is for UI to check authentication 
    /// </summary>
    /// <returns></returns>
    [Authorize]
    [HttpGet]
    public ApiResult CheckToken()
        => new ApiResult(true, ApiResultStatusCode.Success);

    /// <summary>
    /// this is for UI to check authentication 
    /// </summary>
    /// <returns></returns>
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public ApiResult CheckAdmGuidoken()
        => new ApiResult(true, ApiResultStatusCode.Success);

    #endregion


    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Authorize]
    [HttpGet("{id}")]
    public async Task<ApiResult<UserSelectDto>> GetBriefInfo(Guid id, CancellationToken cancellationToken)
            => await ReturnData(id, cancellationToken);

    /// <summary>
    /// This method generate JWT Token
    /// </summary>
    /// <param name="tokenRequest">The information of token request</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [AllowAnonymous]
    public virtual async Task<ApiResult<AccessToken>> Token([FromForm] TokenRequest tokenRequest, CancellationToken cancellationToken)
    {
        if (!tokenRequest.grant_type.Equals("password", StringComparison.OrdinalIgnoreCase))
            return new BadRequestObjectResult("OAuth flow is not password.");
        var accessToken = await Service.CreateToken(tokenRequest.username, tokenRequest.password, cancellationToken);

        return accessToken;
    }

    /// <summary>
    /// Users can reset their password through this action
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpPut]
    public async Task<ApiResult> ResetPassword([FromForm] PasswordchangeDto dto, CancellationToken cancellationToken)
    {
        await Service.ResetPassword(dto.UserName, dto.Email, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Create New User
    /// </summary>
    /// <param name="userDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [AllowAnonymous]
    public override async Task<ApiResult<UserSelectDto>> Create(UserDto userDto, CancellationToken cancellationToken)
    {
        //userDto.ImagePath = await userDto.Image.SaveTo(cancellationToken, ".");

        var user = await Service.AddAsync(userDto.ToEntity(_mapper), cancellationToken, !userDto.IsInRole);
        if (userDto.IsInRole)
        {
            await userManager.AddToRoleAsync(user, "Admin");
        }
        else
        {
            await userManager.AddToRoleAsync(user, "User");
        }


        UserDetail userDetail = new UserDetail(); 
        userDetail.UserId = user.Id;
        userDetail.Accounts = _mapper.Map<List<Account>>(userDto.Accounts);

        var ResuserDetail = await UserDetailService.AddAsync(userDetail, cancellationToken);

        var AddedUser = _mapper.Map<UserSelectDto>(user);
         
        return AddedUser;

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "SuperAdmin")]
    public async Task<ApiResult> BlockSomeOne(Guid id, CancellationToken cancellationToken)
    {
        var isSuperAdmin = roles.Contains("SuperAdmin");
        if (UserId != id && !isSuperAdmin)
            return Unauthorized();
        var realUser = await Service.GetByIdAsync(id, cancellationToken);
        realUser.Block = !realUser.Block;
        await Service.UpdateAsync(realUser, cancellationToken);
        return Ok();
    }




    /// <summary>
    /// Update existance user
    /// </summary>
    /// <param name="id"></param>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Authorize]
    [HttpPut("{id}")]
    public override async Task<ApiResult<UserSelectDto>> Update(Guid id, [FromForm] UserDto user, CancellationToken cancellationToken)
    {
        var isSuperAdmin = roles.Contains("SuperAdmin");
        if (UserId != id && !isSuperAdmin)
            return Unauthorized();
        var realUser = await Service.GetByIdAsync(id, cancellationToken);
        user.UserName = (isSuperAdmin) ? user.UserName : realUser.UserName;
        user.PasswordHash = realUser.PasswordHash;
        user.Id = (isSuperAdmin) ? id : UserId;


        //if (!(user.Image is null) && !(user.ImagePath is null))
        //{
        //    try
        //    {
        //        var add = Path.Combine(_siteSetting.ImageSource, user.ImagePath);
        //        // Check if file exists with its full path    
        //        if (System.IO.File.Exists(add))
        //        {
        //            // If file found, delete it    
        //            System.IO.File.Delete(add);

        //        }
        //    }
        //    catch (IOException)
        //    {
        //        //throw ioExp;
        //    }
        //}
        //  await user.SaveFiles(cancellationToken, _siteSetting.ImageSource);





        user.ToEntity(_mapper, realUser);

        await Service.UpdateAsync(realUser, cancellationToken);


        var userRoles = await userManager.GetRolesAsync(realUser);
        if (user.IsInRole && !userRoles.Contains("Admin"))
            await userManager.AddToRoleAsync(realUser, "Admin");
        if (!user.IsInRole && userRoles.Contains("Admin"))
            await userManager.RemoveFromRoleAsync(realUser, "Admin");
        return await ReturnData(user.Id, cancellationToken);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Authorize]
    [HttpPut]
    public async Task<ApiResult<UserSelectDto>> UpdateMyAcc([FromForm] UserDto user, CancellationToken cancellationToken)
           => await this.Update(UserId, user, cancellationToken);


    /// <summary>ssms
    /// Deletes A user
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public override async Task<ApiResult> Delete(Guid id, CancellationToken cancellationToken)
    {

        var resUserRecipient = (await UserDetailService.GetAllByCondition(x => x.UserId == id, cancellationToken)).FirstOrDefault();
        await UserDetailService.DeleteAsync(resUserRecipient, cancellationToken);
        await Service.DeleteAsync(new User() { Id = id }, cancellationToken);
        return Ok();
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Authorize]
    [HttpPut]
    public async Task<ApiResult> changePassword(PasswordchangeDto dto, CancellationToken cancellationToken)
    {

        var me = await userManager.FindByIdAsync(UserId.ToString());
        // var me = await Service.GetByIdAsync(UserId, cancellationToken);
        await Service.ChangePassword(me, dto.OldPass, dto.NewPassword);
        return Ok();
    }


    /// <summary>
    /// Admin can reset user's password via this action
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Authorize(Roles = "Admin")]
    [HttpPut]
    public async Task<ApiResult> ResetPasswordForce(PasswordchangeDto dto, CancellationToken cancellationToken)
    {
        await Service.ResetPasswordViaId(dto.UserId, cancellationToken);
        return Ok();
    }

}
