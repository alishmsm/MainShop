using Client.Shop.ClientServices.Product;
using Microsoft.AspNetCore.Components;
using Shope.Common.DTO.Product;

namespace Client.Shop.Pages;

public class ProductList : ComponentBase
{
    
    [Inject]
    public IProductService productService{ get; set; }

    public List<ProductDto> Products { get; set; } = new List<ProductDto>();

    public async Task DeleteProduct(int id)
    {
        var response = await productService.DeleteProduct(id);
        if (response.Data == true)
        {
            await GetData();
            StateHasChanged();
        }
    }
    
    protected override async Task OnInitializedAsync()
    {
        // var response = await productService.GetProduct();
        // Products = response.Data;
        await GetData();

    }

    private async Task GetData()
    {
        var response = await productService.GetProduct();
        Products = response.Data;
    }
    
}