
using Assesment.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Assesment.Persistence
{
    public class AssesmentApiDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users {get;set;}

        public AssesmentApiDbContext(DbContextOptions<AssesmentApiDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
             
             builder.Entity<User>()
                .HasMany(u => u.Products)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            builder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);
        }

        public IEnumerable<object> GetAllProducts()
        {
            return   Products;
        }
    }
}

