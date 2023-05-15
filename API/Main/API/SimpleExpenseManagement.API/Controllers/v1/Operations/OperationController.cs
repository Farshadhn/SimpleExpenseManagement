using AutoMapper;
using AutoMapper.QueryableExtensions;
using SimpleExpenseManagement.API.Models.Operations;
using SimpleExpenseManagement.Core.Infrastructure.Operations;
using SimpleExpenseManagement.Core.Models.Operations;
using Lookif.Layers.WebFramework.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



using Microsoft.EntityFrameworkCore;

namespace SimpleExpenseManagement.API.Controllers.v1.Operations;

[ApiVersion("1")]
public class OperationController : CrudController<OperationDto, OperationSelectDto, Operation, IOperationService>
{
    private readonly IMapper _mapper;


    public OperationController(IMapper mapper) : base(mapper)
    {
        _mapper = mapper;
    }
  
    public async override Task<Dictionary<string, string>> GetDropDown(string fieldName, CancellationToken cancellationToken)
    {

        var dto = await Service.GetAll().Where(x => x.LastEditedUserId == UserId).ProjectTo<OperationSelectDto>(Mapper.ConfigurationProvider)
               .ToDictionaryAsync(x => x.Id.ToString(), x => x.Definition.ToString());
        return dto;

    }

}
