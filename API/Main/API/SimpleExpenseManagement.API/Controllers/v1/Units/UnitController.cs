using AutoMapper;
using AutoMapper.QueryableExtensions;
using SimpleExpenseManagement.API.Models.Units;
using SimpleExpenseManagement.Core.Infrastructure.Units;
using SimpleExpenseManagement.Core.Models.Units;
using Lookif.Layers.WebFramework.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SimpleExpenseManagement.API.Controllers.v1.Units
{
    [ApiVersion("1")]
    public class UnitController : CrudController<UnitDto, UnitSelectDto, Unit, IUnitService>
    {
        private readonly IMapper _mapper;


        public UnitController(IMapper mapper) : base(mapper)
        {
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async override Task<ApiResult<List<UnitSelectDto>>> Get(CancellationToken cancellationToken)
        {
            return await Service.GetAll().Where(x => x.LastEditedUserId == UserId).ProjectTo<UnitSelectDto>(_mapper.ConfigurationProvider)
          .ToListAsync(cancellationToken);
        }

        public async override Task<Dictionary<string, string>> GetDropDown(string fieldName, CancellationToken cancellationToken)
        {

            var dto = await Service.GetAll().Where(x => x.LastEditedUserId == UserId).ProjectTo<UnitSelectDto>(Mapper.ConfigurationProvider)
                   .ToDictionaryAsync(x => x.Id.ToString(), x => x.Title.ToString());
            return dto;

        }
    }
}
