using Microsoft.EntityFrameworkCore;

namespace Szkolenie3API.Data
{
    public class ProjektDbContext : DbContext
    {
        public ProjektDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Dog> dogs { get; set; }
        public DbSet<Cat> cats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Dog>().HasData(
                new Dog
                {
                    Id = 1,
                    Breed = "Akita",
                    Color = "Ginger",
                    Weight = 30.5,
                    Description = "Akitas are quiet, fastidious dogs. Wary of strangers and often intolerant of other animals, Akitas will gladly share their silly, affectionate side with family and friends."
                },
                new Dog
                {
                    Id = 2,
                    Breed = "Labrador Retriever",
                    Color = "Yellow",
                    Weight = 25.0,
                    Description = "Labrador Retrievers are friendly, outgoing, and eager to please. They are intelligent and versatile, excelling in various roles, including search and rescue, therapy work, and assistance to people with disabilities."
                },
                new Dog
                {
                    Id = 3,
                    Breed = "Bulldog",
                    Color = "White",
                    Weight = 25.0,
                    Description = "Bulldogs are known for their sturdy build and distinctive pushed-in nose. Despite their tough appearance, they are generally gentle and great with children."
                },
                new Dog
                {
                    Id = 4,
                    Breed = "German Shepherd",
                    Color = "Tan and Black",
                    Weight = 75.0,
                    Description = "German Shepherds are highly intelligent and versatile dogs. They are often used as working dogs in roles such as search and rescue, police, and service dogs."
                }
            );
            modelBuilder.Entity<Cat>().HasData(
                new Cat
                {
                    Id = 1,
                    Breed = "Maine Coon",
                    Color = "Tabby",
                    Weight = 15.0,
                    Description = "Maine Coons are large, long-haired cats known for their friendly and sociable nature. They are often referred to as the 'gentle giants' of the cat world."
                },
                new Cat
                {
                    Id = 2,
                    Breed = "Siamese",
                    Color = "Seal Point",
                    Weight = 8.0,
                    Description = "Siamese cats are known for their striking blue eyes and distinctive color points on their ears, face, paws, and tail. They are highly vocal and social cats."
                },
                new Cat
                {
                    Id = 3,
                    Breed = "Persian",
                    Color = "White",
                    Weight = 10.0,
                    Description = "Persian cats have long, luxurious coats and a distinctive flat face. They are calm and gentle companions, often enjoying a relaxed lifestyle."
                },
                new Cat
                {
                    Id = 4,
                    Breed = "Abyssinian",
                    Color = "Ruddy",
                    Weight = 6.0,
                    Description = "Abyssinians are active and playful cats with short, ticked coats. They are known for their curious and outgoing personalities."
                },
                new Cat
                {
                    Id = 5,
                    Breed = "Scottish Fold",
                    Color = "Blue",
                    Weight = 7.0,
                    Description = "Scottish Folds have unique folded ears that give them a distinctive appearance. They are known for their sweet and gentle temperament."
                }
            );
        }
    }
}
