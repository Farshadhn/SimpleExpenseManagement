using AutoMapper;
using AutoMapper.QueryableExtensions;
using SimpleExpenseManagement.API.Models.Operations;
using SimpleExpenseManagement.Core.Infrastructure.Operations;
using SimpleExpenseManagement.Core.Models.Operations;
using Lookif.Layers.WebFramework.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



using Microsoft.EntityFrameworkCore;

namespace SimpleExpenseManagement.API.Controllers.v1.Operations
{
    [ApiVersion("1")]
    public class OperationController : CrudController<OperationDto, OperationSelectDto, Operation, IOperationService>
    {
        private readonly IMapper _mapper;


        public OperationController(IMapper mapper) : base(mapper)
        {
            _mapper = mapper;
        }
        [Authorize]
        [HttpPost]
        public async override Task<ApiResult<OperationSelectDto>> Create(OperationDto dto, CancellationToken cancellationToken)
        {
            dto.UserId = UserId;
            var operation = await Service.AddOperation(_mapper.Map<Operation>(dto), dto.TagList?.ToList(), cancellationToken);
            return _mapper.Map<OperationSelectDto>(operation);
        }
        [Authorize]
        [HttpGet]
        public async override Task<ApiResult<List<OperationSelectDto>>> Get(CancellationToken cancellationToken)
        {
            var operations = await Service.GetAll().Where(x => x.UserId == UserId).Include(x => x.From).Include(x => x.To).Include(x => x.Tags).ThenInclude(xx => xx.Tag).ToListAsync(cancellationToken);

            var retValue = operations.Select(
                x => new OperationSelectDto()
                {
                    IsActive = x.IsActive,
                    Id = x.Id,
                    FromTitle = x.From.Title,
                    FromId = x.FromId,
                    ToId = x.ToId,
                    ToTitle = x.To.Title,
                    DateTime = x.DateTime,
                    Amount = x.Amount,
                    TypeOfOperation = x.TypeOfOperation,
                    Definition = x.Definition,

                    TagList = x.Tags.Select(x => x.Tag.Id).ToList(),
                    tags = String.Join(',', x.Tags.Select(x => x.Tag.Title))
                }
                ); ;
            return retValue.ToList();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async override Task<ApiResult<OperationSelectDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            var operations = await Service.GetAll().Include(x => x.Tags).ThenInclude(xx => xx.Tag).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            var retValue = new OperationSelectDto()
            {
                IsActive = operations.IsActive,
                Id = operations.Id,
                FromId = operations.FromId,
                ToId = operations.ToId,
                DateTime = operations.DateTime,
                Amount = operations.Amount,
                TypeOfOperation = operations.TypeOfOperation,
                Definition = operations.Definition,

                TagList = operations.Tags.Select(x => x.Tag.Id).ToList(),
                tags = String.Join(',', operations.Tags.Select(x => x.Tag.Title))
            };

            return retValue;



        }

        [Authorize]
        [HttpPut("{id}")]
        public override async Task<ApiResult<OperationSelectDto>> Update(Guid id, OperationDto dto, CancellationToken cancellationToken)
        {
            try
            {
                dto.Id = id;
                var res = await Service.UpdateOperation_Tag(_mapper.Map<Operation>(dto), dto.TagList?.ToList(), cancellationToken);
                return _mapper.Map<OperationSelectDto>(res);

            }
            catch (Exception e)
            {

                throw;
            }


        }

        [Authorize]
        [HttpDelete("{id}")]
        public async override Task<ApiResult> Delete(Guid id, CancellationToken cancellationToken)
        {

            await Service.DeleteOperation_Tag(id, cancellationToken);
            return await base.Delete(id, cancellationToken);
        }

        public async override Task<Dictionary<string, string>> GetDropDown(string fieldName, CancellationToken cancellationToken)
        {

            var dto = await Service.GetAll().Where(x => x.LastEditedUserId == UserId).ProjectTo<OperationSelectDto>(Mapper.ConfigurationProvider)
                   .ToDictionaryAsync(x => x.Id.ToString(), x => x.Definition.ToString());
            return dto;

        }

    }
}
