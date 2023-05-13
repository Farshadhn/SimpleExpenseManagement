using SimpleExpenseManagement.Core.Models.Tags;
using SimpleExpenseManagement.Share.Models.Tags;
using Lookif.Layers.WebFramework.Api;

namespace SimpleExpenseManagement.API.Models.Tags
{
    public class TagSelectDto : BaseDto<TagSelectDto, Tag, Guid>, ITagSelectDto
    {
        public string Title { get; set; }
        public string Color { get; set; }
        public bool IsActive { get; set; }
        public List<Guid> oprationList { get ; set; }
    }
}
