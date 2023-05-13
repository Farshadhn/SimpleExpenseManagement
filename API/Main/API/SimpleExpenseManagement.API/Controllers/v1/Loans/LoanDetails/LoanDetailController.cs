using AutoMapper;
using AutoMapper.QueryableExtensions;
using SimpleExpenseManagement.API.Models.Loans.LoanDetails;
using SimpleExpenseManagement.Core.Infrastructure.Loans;
using SimpleExpenseManagement.Core.Models.Loans;
using Lookif.Layers.WebFramework.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SimpleExpenseManagement.API.Controllers.v1.Loans.LoanDetails
{
    [ApiVersion("1")]
    public class LoanDetailController : CrudController<LoanDetailDto, LoanDetailSelectDto, LoanDetail, ILoanDetailService>
    {
        private readonly IMapper _mapper;


        public LoanDetailController(IMapper mapper) : base(mapper)
        {
            _mapper = mapper;
        }
        [Authorize]
        [HttpGet]
        public async override Task<ApiResult<List<LoanDetailSelectDto>>> Get(CancellationToken cancellationToken)
        {
            return await Service.GetAll().Where(x => x.LastEditedUserId == UserId).ProjectTo<LoanDetailSelectDto>(_mapper.ConfigurationProvider)
          .ToListAsync(cancellationToken);
        }

    }
}
