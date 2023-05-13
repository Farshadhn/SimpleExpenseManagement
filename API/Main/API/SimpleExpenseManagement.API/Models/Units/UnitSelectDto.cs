using SimpleExpenseManagement.Core.Models.Units;
using SimpleExpenseManagement.Share.Models.Units;
using Lookif.Layers.WebFramework.Api;

namespace SimpleExpenseManagement.API.Models.Units
{
    public class UnitSelectDto : BaseDto<UnitSelectDto, Unit, Guid>, IUnitSelectDto
    {
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
