using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RAI.Lab03.s184934.Core.Entities;

namespace RAI.Lab03.s184934.Web.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<MineralWater> MineralWaters { get; private set; }
    public DbSet<Ion> Ion { get; private set; }
    public DbSet<Packaging> Packaging { get; private set; }
    public DbSet<WaterType> WaterTypes { get; private set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}