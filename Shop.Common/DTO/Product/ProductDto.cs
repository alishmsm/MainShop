using System.ComponentModel.DataAnnotations;
using Shope.Common.DTO.Base;

namespace Shope.Common.DTO.Product;

public class ProductDto : BaseDto
{
    [Required(ErrorMessage = "لطفا نام محصول را وارد کنید")]
    public string Name { get; set; }
    public string Description { get; set; }

}