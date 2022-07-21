using Microsoft.EntityFrameworkCore;
using WebAPI_ORM.storage.entities.implementation;

namespace WebAPI_ORM.storage;

public class CityMapContext : DbContext
{
    public CityMapContext( DbContextOptions<CityMapContext> options ) : base( options ) { }

    public DbSet<City> ? City { get; set; }
    public DbSet<House> ? House { get; set; }
    public DbSet<Flat> ? Flat { get; set; }
    public DbSet<Citizen> ? Citizen { get; set; }

    protected override void OnModelCreating( ModelBuilder builder )
    {
        // builder.Entity<City>( e => e.Navigation(p => p.Houses).AutoInclude() );
        builder.Entity<House>( e => e.Navigation(p => p.City).AutoInclude() );
        builder.Entity<Flat>( e => e.Navigation( p => p.House ).AutoInclude());
        builder.Entity<Citizen>( e => e.Navigation( p => p.Flat ).AutoInclude());
    }
    
}
