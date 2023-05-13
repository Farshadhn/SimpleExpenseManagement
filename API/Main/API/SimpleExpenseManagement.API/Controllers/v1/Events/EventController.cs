using AutoMapper;
using AutoMapper.QueryableExtensions;
using SimpleExpenseManagement.API.Models.Events;
using SimpleExpenseManagement.Core.Infrastructure.Events;
using SimpleExpenseManagement.Core.Models.Events;
using Lookif.Layers.WebFramework.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SimpleExpenseManagement.API.Controllers.v1.Events
{
    [ApiVersion("1")]
    public class EventController : CrudController<EventDto, EventSelectDto, Event, IEventService>
    {
        private readonly IMapper _mapper;


        public EventController(IMapper mapper) : base(mapper)
        {
            _mapper = mapper;
        }


        [Authorize]
        [HttpGet]
        public async override Task<ApiResult<List<EventSelectDto>>> Get(CancellationToken cancellationToken)
        {
            return await Service.GetAll().Where(x => x.LastEditedUserId == UserId).ProjectTo<EventSelectDto>(_mapper.ConfigurationProvider)
          .ToListAsync(cancellationToken);
        }

        public async override Task<Dictionary<string, string>> GetDropDown(string fieldName, CancellationToken cancellationToken)
        {

            var dto = await Service.GetAll().Where(x => x.LastEditedUserId == UserId).ProjectTo<EventSelectDto>(Mapper.ConfigurationProvider)
                   .ToDictionaryAsync(x => x.Id.ToString(), x => x.EventTitle.ToString());
            return dto;

        }

    }
}
