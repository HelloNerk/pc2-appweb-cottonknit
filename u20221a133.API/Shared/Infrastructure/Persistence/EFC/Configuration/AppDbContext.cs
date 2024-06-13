using u20221a133.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using u20221a133.API.Sale.Domain.Model.Aggregates;

namespace u20221a133.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    DbSet<PurchaseOrder>PurchaseOrders{get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<PurchaseOrder>().ToTable("purchase_orders");
        builder.Entity<PurchaseOrder>().HasKey(p=>p.Id);
        builder.Entity<PurchaseOrder>().Property(p=>p.Id).ValueGeneratedOnAdd();
        builder.Entity<PurchaseOrder>().Property(p=>p.Customer).IsRequired();
        builder.Entity<PurchaseOrder>().Property(p=>p.FabricId).IsRequired();
        builder.Entity<PurchaseOrder>().Property(p=>p.City).IsRequired();
        builder.Entity<PurchaseOrder>().Property(p=>p.ResumeUrl).IsRequired();
        builder.Entity<PurchaseOrder>().Property(p=>p.Quantity).IsRequired();
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}