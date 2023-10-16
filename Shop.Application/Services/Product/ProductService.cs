using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shope.Application.Interfaces;
using Shope.Common.DTO.Base;
using Shope.Common.DTO.Product;


namespace Shope.Application.Services.Product;

public class ProductService : IProductService
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;
    public ProductService(IAppDbContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<IEnumerable<ProductDto>>> GetAllProductAsync(int page, int pageSize, string? search = null)
    {
        var query = _context.Products
            .AsNoTracking()
            .Where(x => x.IsDelete == false);
        if (search != null)
        {
            query = query.Where(x => x.Name.Contains(search));
        }
        var Productlist = await query.Skip((page-1) * pageSize)
            .Take(pageSize)
            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        
        return new Response<IEnumerable<ProductDto>>(Productlist);

    }

    public async Task<IEnumerable<ProductDto>> GetAllProductAsync()
    {
        var query = _context.Products
            .AsNoTracking()
            .Where(x => x.IsDelete == false);
        var Productlist = await query
            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        
        return Productlist.ToList();

    }
    public async Task<Response<ProductDto>> GetProductByIdAsync(int id)
    {
        var Item = await _context.Products.AsNoTracking()
            .Where(x => x.IsDelete == false)
            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(p => p.Id == id);
        return new Response<ProductDto>(Item);
    }

    public async Task<Response<bool>> CreateProductAsync(ProductDto _product)
    {

        bool productExists = await _context.Products
            .AnyAsync(p => p.Name == _product.Name);

        if (!productExists)
        {
            _product.CreatDate = DateTime.Now;
            var product = _mapper.Map<Domain.Entities.Product.Product>(_product);

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            
            return new Response<bool>(true,true,"Product successfully Created");
        }
        return new Response<bool>(false,true,"this product is Exist!");
       
    }

    public async Task<Response<bool>> DeleteProductAsync(int id)
    {
        var Item = await _context.Products
            .Where(x => x.IsDelete == false)
            .FirstOrDefaultAsync(p => p.Id == id);
        Item.IsDelete = true;
        Item.DeleteDate = DateTime.Now;
        await _context.SaveChangesAsync();
        return new Response<bool>(true,true,"this product is deleted successfully");
    }


    public async Task<Response<ProductDto?>> UpdateProductAsync(ProductDto _product)
    {
        
        var Item = await _context.Products
            .Where(x => x.IsDelete == false)
            .FirstOrDefaultAsync(p => p.Id == _product.Id);
        if (Item != null)
        {
            _mapper.Map(_product, Item);
            await _context.SaveChangesAsync();
            return new Response<ProductDto?>(_product);
        }
        
        return new Response<ProductDto?>(null,false,"this product dosn't Exist!");
        
    }
    
}