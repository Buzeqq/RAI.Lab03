using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Core.Entities;

namespace RAI.Lab03.s184934.Web.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<MineralWater> MineralWaters { get; private set; }
    private DbSet<Ion> Ion { get; set; }
    public DbSet<Cation> Cations { get; private set; }
    public DbSet<Anion> Anions { get; private set; }
    public DbSet<Packaging> Packaging { get; private set; }
    public DbSet<WaterType> WaterTypes { get; private set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Producer> Producers { get; private set; }
    public DbSet<Supplier> Supplier { get; private set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(builder);
    }
}