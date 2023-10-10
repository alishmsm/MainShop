using Shope.Domain.Entities.Common;

namespace Shope.Domain.Entities.Category;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public string? Icon { get; set; }
    public short Order { get; set; }
    public ICollection<Product.Product>  Products { get; set; }
}