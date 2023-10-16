using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shope.Application.Services.Product;
using Shope.Common.DTO.Base;
using Shope.Common.DTO.Product;

namespace EndPoint.Site.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;
    
    public ProductController(IProductService service)
    {
        _service = service;
    }
    

    [HttpGet]
    public async Task<IActionResult> GetAllProductAsync([FromQuery]int page,int pageSize,string? search)
    {
        var Result = await _service.GetAllProductAsync(page,pageSize,search);
        return Ok(Result);
        
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserAsync(int id)
    {
        var Result = await _service.GetProductByIdAsync(id);
        return Ok(Result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(ProductDto product)
    {
        var Result = await _service.CreateProductAsync(product);
        return Ok(Result);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var Result = await _service.DeleteProductAsync(id);
        return Ok(Result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductAsync(ProductDto product)
    {
        var Result = await _service.UpdateProductAsync(product);
        return Ok(Result);
    }

}