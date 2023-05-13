using AutoMapper;
using AutoMapper.QueryableExtensions;
using SimpleExpenseManagement.API.Models.Tags.Operation_Tags;
using SimpleExpenseManagement.Core.Infrastructure.Tags;
using SimpleExpenseManagement.Core.Models.Tags;
using Lookif.Layers.WebFramework.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SimpleExpenseManagement.API.Controllers.v1.Tags
{
    [ApiVersion("1")]
    public class Operation_TagController : CrudController<Operation_TagDto, Operation_TagSelectDto, Operation_Tag, IOperation_TagService>
    {
        private readonly IMapper _mapper;


        public Operation_TagController(IMapper mapper) : base(mapper)
        {
            _mapper = mapper;
        }
        [Authorize]
        [HttpGet]
        public async override Task<ApiResult<List<Operation_TagSelectDto>>> Get(CancellationToken cancellationToken)
        {
            return await Service.GetAll().Where(x => x.LastEditedUserId == UserId).ProjectTo<Operation_TagSelectDto>(_mapper.ConfigurationProvider)
          .ToListAsync(cancellationToken);
        }

    }
}
