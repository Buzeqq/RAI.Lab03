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

    public DbSet<MineralWater> MineralWaters { get; }
    public DbSet<Ion> Ion { get; set; }
    public DbSet<Cation> Cations { get; }
    public DbSet<Anion> Anions { get; }
    public DbSet<Packaging> Packaging { get; }
    public DbSet<WaterType> WaterTypes { get; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Producer> Producers { get; }
    public DbSet<Supplier> Supplier { get; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(builder);
    }
}