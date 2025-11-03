using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(

                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Fortunes of Times",
                    Description = "A motivational journey through success, failure, and the lessons of time.",
                    ISBN = "978-1000000001",
                    Author = "James Holden",
                    ListPrice = 899,
                    Price = 850,
                    Price50 = 800,
                    Price100 = 750
                },
                new Product
                {
                    Id = 2,
                    Title = "Dark Skies Leaves and Wonders",
                    Description = "An emotional story exploring love, loss, and hope beneath dark skies.",
                    ISBN = "978-1000000002",
                    Author = "Amelia Grant",
                    ListPrice = 799,
                    Price = 760,
                    Price50 = 720,
                    Price100 = 680
                },
                new Product
                {
                    Id = 3,
                    Title = "Rock in the Ocean",
                    Description = "A tale of resilience and courage as one stands strong against life's storms.",
                    ISBN = "978-1000000003",
                    Author = "William Carter",
                    ListPrice = 950,
                    Price = 900,
                    Price50 = 850,
                    Price100 = 800
                },
                new Product
                {
                    Id = 4,
                    Title = "Cotton Candy",
                    Description = "A lighthearted romantic comedy full of sweetness, laughter, and nostalgia.",
                    ISBN = "978-1000000004",
                    Author = "Sophie Turner",
                    ListPrice = 699,
                    Price = 650,
                    Price50 = 600,
                    Price100 = 550
                },
                new Product
                {
                    Id = 5,
                    Title = "Vanish in the Sunset",
                    Description = "A mysterious thriller about disappearing truths and chasing the impossible.",
                    ISBN = "978-1000000005",
                    Author = "Noah Anderson",
                    ListPrice = 999,
                    Price = 950,
                    Price50 = 900,
                    Price100 = 850
                },
                new Product
                {
                    Id = 6,
                    Title = "Whispers of Tomorrow",
                    Description = "A futuristic sci-fi story about destiny, hope, and second chances.",
                    ISBN = "978-1000000006",
                    Author = "Luna Harper",
                    ListPrice = 899,
                    Price = 860,
                    Price50 = 820,
                    Price100 = 780
                }
            );
        }
    }
}
