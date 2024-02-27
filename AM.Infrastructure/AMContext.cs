using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure;

public class AMContext:DbContext //Héritage
{
    //DBSet
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Passenger> Passengers { get; set; }
    public DbSet<Plane> Planes { get; set; }
    public DbSet<Staff> Staff { get; set; }
    public DbSet<Traveller> Travellers { get; set; }
    //Config de connexion
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=192.168.100.133,1433;
                                    Database=AirportManagementDB;
                                    User=sa;
                                    Password=ROOTroot13@;
                                    MultipleActiveResultSets=true;
                                    TrustServerCertificate=True;");
        base.OnConfiguring(optionsBuilder);
    }

    

    //Régles de mapping Fluent API (pérsonalisées)
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 1er methode : Fluent API avec des classes de config
        // modelBuilder.ApplyConfiguration(new PlaneConfiguration()); //Appliquer les config dans les classes sous Configurations
        //2eme methode: Fluent API sans classe de config
        modelBuilder.Entity<Plane>().HasKey(p => p.PlaneId);
        modelBuilder.Entity<Plane>().ToTable("MyPlanes");
        modelBuilder.Entity<Plane>().Property(p => p.Capacity).HasColumnName("PlaneCapacity");
        
        modelBuilder.ApplyConfiguration(new FlightConfiguration()); //Appliquer les config dans les classes sous Configurations
        base.OnModelCreating(modelBuilder);
    }
    //Conventions relatives a tout le modéle

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateTime>().HaveColumnType("datetime");
        base.ConfigureConventions(configurationBuilder);
    }
}