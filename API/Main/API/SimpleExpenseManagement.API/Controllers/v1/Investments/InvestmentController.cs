using AutoMapper;
using AutoMapper.QueryableExtensions;
using SimpleExpenseManagement.API.Models.Investments;
using SimpleExpenseManagement.Core.Infrastructure.Investments;
using SimpleExpenseManagement.Core.Models.Investments;
using Lookif.Layers.WebFramework.Api;
using Lookif.Library.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SimpleExpenseManagement.API.Controllers.v1.Investments
{
    [ApiVersion("1")]
    public class InvestmentController : CrudController<InvestmentDto, InvestmentSelectDto, Investment, IInvestmentService>
    {
        private readonly IMapper _mapper;


        public InvestmentController(IMapper mapper) : base(mapper)
        {
            _mapper = mapper;
        }
        [Authorize]
        [HttpGet]
        public async override Task<ApiResult<List<InvestmentSelectDto>>> Get(CancellationToken cancellationToken)
        {
            var res =  await Service.GetAll().Where(x => x.LastEditedUserId == UserId).ProjectTo<InvestmentSelectDto>(_mapper.ConfigurationProvider)
          .ToListAsync(cancellationToken);
            return res;
        }
       


    }
}
