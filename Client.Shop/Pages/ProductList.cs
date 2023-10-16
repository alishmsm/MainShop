using Client.Shop.ClientServices.Product;
using Microsoft.AspNetCore.Components;
using Shope.Common.DTO.Product;

namespace Client.Shop.Pages;

public class ProductList : ComponentBase
{


    [Inject]
    public IProductService productService{ get; set; }

    public List<ProductDto> Products { get; set; } = new List<ProductDto>();
    
    protected override async Task OnInitializedAsync()
    {
        var response = await productService.GetEmployees();
        // Products = response.Data;
    }
}