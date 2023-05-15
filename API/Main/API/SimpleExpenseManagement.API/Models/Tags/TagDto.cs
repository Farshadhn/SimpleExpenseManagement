using SimpleExpenseManagement.Core.Models.Tags;
using SimpleExpenseManagement.Share.Models.Tags;
using Lookif.Layers.WebFramework.Api;

namespace SimpleExpenseManagement.API.Models.Tags
{
    public class TagDto : BaseDto<TagDto, Tag, Guid>, ITagDto
    {
        public string Title { get; set; }
        public string Color { get; set; }
        public bool IsActive { get; set; }
    }
}
