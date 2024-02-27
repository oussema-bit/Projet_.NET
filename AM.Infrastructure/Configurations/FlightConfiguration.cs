using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configurations;

public class FlightConfiguration:IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        //Many to many RS Passenger==>Flight
        builder.HasMany(f => f.Passengers)
            .WithMany(p => p.Flights)
            .UsingEntity(t=>t.ToTable("Reservations"));
        builder.HasOne(f => f.Plane)
            .WithMany(p => p.Flights)
            .HasForeignKey(f=>f.PlaneFK)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

    }
}