using AutoMapper;
using AutoMapper.QueryableExtensions;
using SimpleExpenseManagement.API.Models.Accounts;
using SimpleExpenseManagement.Core.Infrastructure.Accounts;
using SimpleExpenseManagement.Core.Models.Accounts;
using Lookif.Layers.WebFramework.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SimpleExpenseManagement.API.Controllers.v1.Accounts;

[ApiVersion("1")]
public class AccountVisibilityController : CrudController<AccountVisibilityDto, AccountVisibilitySelectDto, AccountVisibility, IAccountVisibilityService>
{
    private readonly IMapper _mapper;


    public AccountVisibilityController(IMapper mapper) : base(mapper)
    {
        _mapper = mapper;
    }
    [Authorize]
    [HttpGet]
    public async override Task<ApiResult<List<AccountVisibilitySelectDto>>> Get(CancellationToken cancellationToken)
    {
        return await Service.GetAll().Where(x => x.LastEditedUserId == UserId).ProjectTo<AccountVisibilitySelectDto>(_mapper.ConfigurationProvider)
       .ToListAsync(cancellationToken);
    }

    public async override Task<Dictionary<string, string>> GetDropDown(string fieldName, CancellationToken cancellationToken)
    {

        var dto = await Service.GetAll().Where(x => x.LastEditedUserId == UserId).ProjectTo<AccountVisibilitySelectDto>(Mapper.ConfigurationProvider)
               .ToDictionaryAsync(x => x.Id.ToString(), x => x.AccountTitle.ToString());
        return dto;

    }
}
