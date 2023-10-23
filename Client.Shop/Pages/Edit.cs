using Client.Shop.ClientServices.Product;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shope.Common.DTO.Product;
namespace Client.Shop.Pages;
public partial class Edit
{
    [Inject]
    public IJSRuntime JsRuntime { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }
    [Inject]
    public IProductService productService { get; set; }
    [Parameter]
    public int Id { get; set; }
    public ProductDto Product { get; set; } = new ProductDto();
    protected override async Task OnInitializedAsync()
    {
        await GetData(Id);
    }

    private async Task GetData(int id)
    {
        var response = await productService.GetProductById(id);
        Product = response.Data;
    }
    public async Task EditProduct()
    {
        var response = await productService.EditProduct(Product);
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