using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Core.Entities;

namespace RAI.Lab03.s184934.Web.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}

public class WarehouseDbContext : DbContext
{
    public DbSet<MineralWater> MineralWaters { get; set; }
    public DbSet<Ion> Ion { get; set; }
    public DbSet<Cation> Cations { get; set; }
    public DbSet<Anion> Anions { get; set; }
    public DbSet<Packaging> Packaging { get; set; }
    public DbSet<WaterType> WaterTypes { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Producer> Producers { get; set; }
    public DbSet<Supplier> Supplier { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }
    public DbSet<Pallet> Pallets { get; set; }
    
    public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}