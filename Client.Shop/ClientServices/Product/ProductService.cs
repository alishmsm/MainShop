using Shope.Common.DTO.Product;
using System.Net.Http.Json;
using System.Text.Json;
using Shope.Common.DTO.Base;

namespace Client.Shop.ClientServices.Product;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<Response<List<ProductDto>>?> GetProduct()
    {
        var result = await _httpClient.GetFromJsonAsync<Response<List<ProductDto>>>($"api/Product?page=1&pageSize=3&search={"a"}");
        return result;


    }

}