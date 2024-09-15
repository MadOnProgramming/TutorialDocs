using Microsoft.EntityFrameworkCore;
using Sample.Domain;

namespace Sample.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
            
            //ensure database is created
            Database.EnsureCreated();
        }

        //context
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //Database seeding
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().HasData(
                new Product("Product1","Product1",1),
                new Product("Product2","Product2",2),
                new Product("Product3","Prouduct3",3));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //specify the kind of database
            optionsBuilder.UseInMemoryDatabase("my_cqrs_sample");
        }
    }
}
