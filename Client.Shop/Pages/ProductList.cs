using Client.Shop.ClientServices.Product;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
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
        PageSize = 10;
        CurrentPage = 1;
        // var response = await productService.GetProduct();
        // Products = response.Data;
        await GetData();

    }

    protected async Task GetData()
    {
        var response = await productService.GetProduct(CurrentPage,PageSize,SearchKey);
        Products = response.Data;
        TotalCount = response.TotalCount;
        
    }
    //---------------------------Search-------------------------

    protected async Task Search(string s)
    {
        SearchKey = s;
        CurrentPage = 1;
        
        await GetData();
        StateHasChanged();
        
    }
    public string? SearchKey { get; set; }
    //-------------------------Pagination-----------------------
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    public int TotalCount { get; set; }

    public async Task ChangePage(int currentPage)
    {
        CurrentPage = currentPage;
        await GetData();
        StateHasChanged();
        
    }
    
    
}