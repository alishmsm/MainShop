using Client.Shop.ClientServices.Product;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shope.Common.DTO.Product;

namespace Client.Shop.Pages;

public partial class CreateProduct
{
    public bool success { get; set; }
    [Inject] 
    public IProductService productService { get; set; }
    [Inject]
    public IJSRuntime JsRuntime { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    public ProductDto Product { get; set; } = new ProductDto();
    // public string Message { get; set; }
    protected override void OnInitialized()
    {
        Product.CreatDate = DateTime.Now.Date;
    }

    public async Task _CreateProduct()
    {
        var response = await productService.CreatProduct(Product);
        if (response.IsSucces)
        {
            NavigationManager.NavigateTo("/");
        }
        else
        {
            await Alert(response.Message);
        }
    }


    private async Task Alert(string message)
    {
        await JsRuntime.InvokeVoidAsync("Alert", message);
    }

}