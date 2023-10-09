using Microsoft.EntityFrameworkCore;
using ReviewerApp.Models;

namespace ReviewerApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :
            base(options)
        {
            
        }
        public DbSet<Category>  Categories  { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pokeman> Pokemans { get; set; }
        public DbSet<PokemanOwner> PokemanOwners { get; set; }
        public DbSet<PokemanCategory> PokemanCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemanCategory>()
                .HasKey(pc => new { pc.PokemanId, pc.CategoryId });
            modelBuilder.Entity<PokemanCategory>()
                .HasOne(p => p.Pokeman)
                .WithMany(pc => pc.PokemanCategories)
                .HasForeignKey(p => p.PokemanId);
            modelBuilder.Entity<PokemanCategory>()
                .HasOne(p => p.Category)
                .WithMany(pc => pc.PokemanCategories)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<PokemanOwner>()
               .HasKey(pc => new { pc.PokemanId, pc.OwnerId});
            modelBuilder.Entity<PokemanOwner>()
                .HasOne(p => p.Pokeman)
                .WithMany(pc => pc.PokemanOwners)
                .HasForeignKey(p => p.PokemanId);
            modelBuilder.Entity<PokemanOwner>()
                .HasOne(p => p.Owner)
                .WithMany(pc => pc.PokemanOwners)
                .HasForeignKey(p => p.OwnerId);
             
        }
    }
}
