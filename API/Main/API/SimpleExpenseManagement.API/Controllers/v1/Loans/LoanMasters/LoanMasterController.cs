using AutoMapper;
using AutoMapper.QueryableExtensions;
using SimpleExpenseManagement.API.Models.Loans.LoanMasters;
using SimpleExpenseManagement.Core.Infrastructure.Loans;
using SimpleExpenseManagement.Core.Models.Loans;
using Lookif.Layers.WebFramework.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SimpleExpenseManagement.API.Controllers.v1.Loans.LoanMasters
{
    [ApiVersion("1")]
    public class LoanMasterController : CrudController<LoanMasterDto, LoanMasterSelectDto, LoanMaster, ILoanMasterService>
    {
        private readonly IMapper _mapper;

        public LoanMasterController(IMapper mapper) : base(mapper)
        {
            _mapper = mapper;
        }
        [Authorize]
        [HttpGet]
        public async override Task<ApiResult<List<LoanMasterSelectDto>>> Get(CancellationToken cancellationToken)
        {
            return await Service.GetAll().Where(x => x.LastEditedUserId == UserId).ProjectTo<LoanMasterSelectDto>(_mapper.ConfigurationProvider)
          .ToListAsync(cancellationToken);
        }
    }
}
