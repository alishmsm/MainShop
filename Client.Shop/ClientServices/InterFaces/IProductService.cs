using Shope.Common.DTO.Base;
using Shope.Common.DTO.Product;

namespace Client.Shop.ClientServices.Product;

public interface IProductService
{
    Task<Response<ProductDto>?> EditProduct(ProductDto product);
    Task<Response<ProductDto>> GetProductById(int id);
    Task<Response<List<ProductDto>>?> GetProduct();
    Task<Response<bool>> CreatProduct(ProductDto product);
    Task<Response<bool>> DeleteProduct(int id);
}