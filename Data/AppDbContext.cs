using KodaStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace KodaStore.Api.Data;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>(entity=>
        {
            entity.ToTable("Product", "dbo", table =>
            {
                table.HasCheckConstraint("CK_Product_Price", "[Price] >= 0");
                table.HasCheckConstraint("CK_Product_Stock", "[Stock] >= 0");                
            });

            entity.HasKey(p => p.ProductCode);

            entity.Property(p => p.ProductCode)
                .HasMaxLength(30)
                .IsRequired()
                .ValueGeneratedNever();

            entity.Property(p => p.Name)
                .HasMaxLength(120)
                .IsRequired();

            entity.Property(p => p.Price)
                .IsRequired()
                .HasPrecision(18,2);

            entity.Property(p => p.Stock)
                .IsRequired();

            entity.Property(p => p.Category)
                .HasMaxLength(30)
                .IsRequired();      

            entity.Property(p =>p.Description)
                .HasMaxLength(100);


            entity.HasData(
                new Product("PR01", "Mie Ayam Yamin", 13000, 250,"Mie Ayam"),
                new
                {
                    ProductCode="PR03", 
                    Name = "Bakso Halus", 
                    Price = 15000m, 
                    Stock = 210,
                    Category = "Bakso",
                    Description = "Bakso dg tetelan daging"
                },
                new Product("PR02", "Bakso Campuran", 17000, 250,"Bakso","bakso urat besar, lainnya kecil")
            );      
        });
    }


}