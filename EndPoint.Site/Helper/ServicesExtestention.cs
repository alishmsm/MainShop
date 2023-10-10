
using Shope.Application.Services.Category;
using Shope.Application.Services.Product;
using Shope.Application.Services.User;

namespace EndPoint.Site.Helper;

public static class ServicesExtestention
{
    public static IServiceCollection AddOurServices(this IServiceCollection services)
    {
        // services.AddScoped<>();
        services.AddScoped<IUserService,UserService>();
        services.AddScoped<IProductService,ProductService>();
        services.AddScoped<ICategoryService,CategoryService>();
        return services;
    }
}