using Shope.Domain.Entities.Common;

namespace Shope.Domain.Entities.Product;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Category.Category> Categories { get; set; }
    public ICollection<Image.Image> Images { get; set; }
}