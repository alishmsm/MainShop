
using Microsoft.AspNetCore.Mvc;
using Shope.Application.Services.Category;
using Shope.Common.DTO.Base;
using Shope.Common.DTO.Category;
using Shope.Common.DTO.Product;


namespace EndPoint.Site.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _service;
    
    public CategoryController(ICategoryService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetCategoryAsync([FromQuery]int page,int pageSize,string? search)
    {
        var Result = await _service.GetAllCategoryAsync(page,pageSize,search);
        return Ok(Result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryAsync(int id)
    {
        var Result = await _service.GetCategoryByIdAsync(id);
        return Ok(Result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CategoryDto category)
    {
        var Result = await _service.CreateCategoryAsync(category);
        return Ok(Result);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var Result = await _service.DeleteCategoryAsync(id);
        return Ok(Result);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateCategoryAsync(CategoryDto category)
    {
        var Result = await _service.UpdateCategoryAsync(category);
        return Ok(Result);
    }
}