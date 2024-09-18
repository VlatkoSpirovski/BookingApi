using BookingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Property> Properties { get; set; }
    public DbSet<RatingAndReview> Ratings { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<PropertyAmenity> Amenities { get; set; }
    public DbSet<Photo> Photos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Property>()
            .HasMany(p => p.RatingsAndReviews)
            .WithOne(r => r.Property)
            .HasForeignKey(r => r.PropertyId);

        modelBuilder.Entity<Address>()
           .HasOne(p => p.Property)
           .WithOne(a => a.Address)
           .HasForeignKey<Property>(a => a.AddressId);
        
        modelBuilder.Entity<Property>()
            .HasMany(p => p.Amenities)
            .WithOne(a => a.Property)
            .HasForeignKey(a => a.PropertyAmenId);
        
        modelBuilder.Entity<Photo>()
           .HasOne(p => p.Property)
           .WithMany(ph => ph.Photos)
           .HasForeignKey(ph => ph.PropertyId);
        
        base.OnModelCreating(modelBuilder);
    }
}