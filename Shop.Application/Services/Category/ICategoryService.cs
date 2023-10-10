using Shope.Common.DTO.Base;
using Shope.Common.DTO.Category;

namespace Shope.Application.Services.Category;

public interface ICategoryService
{
    Task<Response<IEnumerable<CategoryDto>>> GetAllCategoryAsync(int page, int pageSize, string search);
    Task<Response<CategoryDto>> GetCategoryByIdAsync(int id);
    Task<Response<bool>> CreateCategoryAsync(CategoryDto _category);
    Task<Response<bool>> DeleteCategoryAsync(int id);
    Task<Response<CategoryDto?>> UpdateCategoryAsync(CategoryDto _category);

}