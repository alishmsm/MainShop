using Shope.Common.DTO.Base;
using Shope.Domain.Entities.Common;

namespace Shope.Common.DTO.Category;

public class CategoryDto : BaseDto
{
    public string Name { get; set; }
    public string? Icon { get; set; }
    public short Order { get; set; }
}