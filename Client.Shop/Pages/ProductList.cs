using Client.Shop.ClientServices.Product;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using Shope.Common.DTO.Product;
namespace Client.Shop.Pages;


public class ProductList : ComponentBase
{
    
    [Inject]
    public IProductService productService{ get; set; }
    [Inject]
    public IDialogService DialogService{ get; set; }
    public List<ProductDto> Products { get; set; } = new List<ProductDto>();

    public async Task _DeleteProduct(int id)
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
    
  
    public async Task PageChanged(int i)
    {
        CurrentPage = i;
        await GetData();
    }

    public int PageCount()
    {
        if (TotalCount % PageSize == 0) return TotalCount / PageSize;
        return TotalCount / PageSize + 1;
    }
    public async Task DeleteProduct(int id)
    {
        
        var parameters = new DialogParameters();
        parameters.Add("ContentText", "آیا از حذف محصول خود اطمینان دارید؟؟");
        parameters.Add("ButtonText", "حذف");
        parameters.Add("Color", Color.Error);
        
        var options = new DialogOptions() { CloseButton = false, MaxWidth = MaxWidth.ExtraSmall };
        
        var dialog = await DialogService.ShowAsync<Dialog>("حذف", parameters, options);
        var Result = await dialog.Result;

        if (!Result.Canceled)
        {
            await _DeleteProduct(id);
        }
    }
    
}