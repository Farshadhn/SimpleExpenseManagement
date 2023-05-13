using AutoMapper;
using AutoMapper.QueryableExtensions;
using SimpleExpenseManagement.API.Models.Tags;
using SimpleExpenseManagement.Core.Infrastructure.Tags;
using SimpleExpenseManagement.Core.Models.Tags;
using Lookif.Layers.WebFramework.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SimpleExpenseManagement.API.Controllers.v1.Tags
{
    [ApiVersion("1")]
    public class TagController : CrudController<TagDto, TagSelectDto, Tag, ITagService>
    {
        private readonly IMapper _mapper;


        public TagController(IMapper mapper) : base(mapper)
        {
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async override Task<ApiResult<List<TagSelectDto>>> Get(CancellationToken cancellationToken)
        {
            return await Service.GetAll().Where(x => x.LastEditedUserId == UserId).ProjectTo<TagSelectDto>(_mapper.ConfigurationProvider)
          .ToListAsync(cancellationToken);
        }

        public async override Task<Dictionary<string, string>> GetDropDown(string fieldName, CancellationToken cancellationToken)
        {

            var dto = await Service.GetAll().Where(x => x.LastEditedUserId == UserId).ProjectTo<TagSelectDto>(Mapper.ConfigurationProvider)
                   .ToDictionaryAsync(x => x.Id.ToString(), x => x.Title.ToString());
            return dto;

        }

    }
}
