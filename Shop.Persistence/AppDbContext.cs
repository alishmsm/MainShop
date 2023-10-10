using System.Net.Mime;
using Microsoft.EntityFrameworkCore;
using Shope.Application.Interfaces;
using Shope.Domain.Entities.Category;
using Shope.Domain.Entities.Common;
using Shope.Domain.Entities.Image;
using Shope.Domain.Entities.Product;
using Shope.Domain.Entities.User;

namespace Shope.Persistence;

public class AppDbContext : DbContext,IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //
        // modelBuilder.Entity<Product>().UseTpcMappingStrategy();
        // modelBuilder.Entity<Category>().UseTpcMappingStrategy();
        // modelBuilder.Entity<Image>().UseTpcMappingStrategy();
        // modelBuilder.Entity<User>().UseTpcMappingStrategy();
        
    }
}