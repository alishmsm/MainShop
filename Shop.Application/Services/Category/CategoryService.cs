using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shope.Application.Interfaces;
using Shope.Common.DTO.Base;
using Shope.Common.DTO.Category;

namespace Shope.Application.Services.Category;

public class CategoryService : ICategoryService
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    public CategoryService(IAppDbContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<IEnumerable<CategoryDto>>> GetAllCategoryAsync(int page, int pageSize, string? search = null)
    {
        var query = _context.Categories
            .AsNoTracking()
            .Where(x => x.IsDelete == false);
        if (search != null)
        {
            query = query.Where(x => x.Name.Contains(search));
        }
        var Categorlist = await query.Skip((page-1) * pageSize)
            .Take(pageSize)
            .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        
        return new Response<IEnumerable<CategoryDto>>(Categorlist);

    }

    public async Task<Response<CategoryDto>> GetCategoryByIdAsync(int id)
    {
        var Item = await _context.Categories.AsNoTracking()
            .Where(x => x.IsDelete == false)
            .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(p => p.Id == id);
        return new Response<CategoryDto>(Item);
    }

    public async Task<Response<bool>> CreateCategoryAsync(CategoryDto _category)
    {

        bool categoryExists = await _context.Categories
            .AnyAsync(p => p.Name == _category.Name);

        if (!categoryExists)
        {
            _category.CreatDate = DateTime.Now;
            var category = _mapper.Map<Domain.Entities.Category.Category>(_category);

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            
            return new Response<bool>(true,true,"Category successfully Created");
        }
        return new Response<bool>(false,true,"this Category is Exist!");
       
    }

    public async Task<Response<bool>> DeleteCategoryAsync(int id)
    {
        var Item = await _context.Categories
            .Where(x => x.IsDelete == false)
            .FirstOrDefaultAsync(p => p.Id == id);
        Item.IsDelete = true;
        Item.DeleteDate = DateTime.Now;
        await _context.SaveChangesAsync();
        return new Response<bool>(true,true,"this Category is deleted successfully");
    }


    public async Task<Response<CategoryDto?>> UpdateCategoryAsync(CategoryDto _category)
    {
        
        var Item = await _context.Categories
            .Where(x => x.IsDelete == false)
            .FirstOrDefaultAsync(p => p.Id == _category.Id);
        if (Item != null)
        {
            _mapper.Map(_category, Item);
            await _context.SaveChangesAsync();
            var categorydto = _mapper.Map<CategoryDto>(Item);
            return new Response<CategoryDto?>(categorydto);
        }
        
        return new Response<CategoryDto?>(null,false,"this Category dosn't Exist!");
        
    }
}