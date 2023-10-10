using System.Net.Mime;
using Microsoft.EntityFrameworkCore;
using Shope.Domain.Entities.Category;
using Shope.Domain.Entities.Product;
using Shope.Domain.Entities.Image;
using Shope.Domain.Entities.User;

namespace Shope.Application.Interfaces;

public interface IAppDbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    
    int SaveChanges(bool acceptAllChangesOnSuccess);
    int SaveChanges();
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    // Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
}