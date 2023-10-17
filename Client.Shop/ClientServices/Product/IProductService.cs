using Shope.Common.DTO.Base;
using Shope.Common.DTO.Product;

namespace Client.Shop.ClientServices.Product;

public interface IProductService
{
    Task<Response<List<ProductDto>>?> GetProduct();
    Task<Response<bool>> CreatProduct(ProductDto produc);
}