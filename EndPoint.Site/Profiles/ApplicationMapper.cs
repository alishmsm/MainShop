using AutoMapper;
using Shope.Common.DTO.Category;
using Shope.Common.DTO.Product;
using Shope.Common.DTO.User;
using Shope.Domain.Entities.Category;
using Shope.Domain.Entities.Product;
using Shope.Domain.Entities.User;

namespace EndPoint.Site.Profiles;

public class ApplicationMapper : Profile
{
    public ApplicationMapper()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, LogupDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}