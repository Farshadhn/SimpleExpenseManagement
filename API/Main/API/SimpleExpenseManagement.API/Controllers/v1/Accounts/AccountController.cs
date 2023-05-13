using AutoMapper;
using AutoMapper.QueryableExtensions;
using SimpleExpenseManagement.API.Models.Accounts;
using SimpleExpenseManagement.Core.Infrastructure.Accounts;
using SimpleExpenseManagement.Core.Infrastructure.Operations;
using SimpleExpenseManagement.Core.Models.Accounts;
using Lookif.Layers.WebFramework.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SimpleExpenseManagement.API.Controllers.v1.Accounts
{
    [ApiVersion("1")]
    public class AccountController : CrudController<AccountDto, AccountSelectDto, Account, IAccountServicecs>
    {
        private readonly IMapper _mapper;
        private readonly IOperationService _OperationService;
        public AccountController(IMapper mapper, IOperationService operationService) : base(mapper)
        {
            _mapper = mapper;
            _OperationService = operationService;
        }
        [Authorize]
        [HttpGet]
        public async override Task<ApiResult<List<AccountSelectDto>>> Get(CancellationToken cancellationToken)
        {
            var res = await Service.GetAll().Where(x => x.LastEditedUserId == UserId).ProjectTo<AccountSelectDto>(_mapper.ConfigurationProvider)
           .ToListAsync(cancellationToken);

            var operations = await _OperationService.GetAll().Where(x => x.UserId == UserId).Include(x => x.From).Include(x => x.To).Include(x => x.Tags).ThenInclude(xx => xx.Tag).ToListAsync(cancellationToken);


            foreach (var item in res)
            {

                var SumToId = operations.Where(x => x.ToId == item.Id).Sum(y => y.Amount);
                var SumFromId = operations.Where(x => x.FromId == item.Id).Sum(y => y.Amount);
                item.Value = item.InitialValue+(SumToId-SumFromId);


            }
            return res;
        }

        public async override Task<Dictionary<string, string>> GetDropDown(string fieldName, CancellationToken cancellationToken)
        {

            var dto = await Service.GetAll().Where(x => x.LastEditedUserId == UserId).ProjectTo<AccountSelectDto>(Mapper.ConfigurationProvider)
                   .ToDictionaryAsync(x => x.Id.ToString(), x => x.Title.ToString());
            return dto;

        }

    }
}
