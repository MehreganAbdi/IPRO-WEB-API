using ReviewerApp.Models;

namespace ReviewerApp.Data
{
    public class SeedData
    {
        private readonly DataContext dataContext;
        public SeedData(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.PokemanOwners.Any())
            {
                var PokemanOwners = new List<PokemanOwner>()
                {
                    new PokemanOwner()
                    {
                        Pokeman = new Pokeman()
                        {
                            Name = "Pikachu",
                            BirthDate = new DateTime(1903,1,1),
                            PokemanCategories = new List<PokemanCategory>()
                            {
                                new PokemanCategory { Category = new Category() { Name = "Electric"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Pikachu",Text = "Pickahu is the best Pokeman, because it is electric", Rating = 5,
                                Reviewer = new Reviewer(){ Name = "Teddy", LastName = "Smith" } },
                                new Review { Title="Pikachu", Text = "Pickachu is the best a killing rocks", Rating = 5,
                                Reviewer = new Reviewer(){ Name = "Taylor", LastName = "Jones" } },
                                new Review { Title="Pikachu",Text = "Pickchu, pickachu, pikachu", Rating = 1,
                                Reviewer = new Reviewer(){ Name = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Jack",
                            LastName = "London",
                            Gym = "Brocks Gym",
                            Country = new Country()
                            {
                                Name = "Kanto"
                            }
                        }
                    },
                    new PokemanOwner()
                    {
                        Pokeman = new Pokeman()
                        {
                            Name = "Squirtle",
                            BirthDate = new DateTime(1903,1,1),
                            PokemanCategories = new List<PokemanCategory>()
                            {
                                new PokemanCategory { Category = new Category() { Name = "Water"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title= "Squirtle", Text = "squirtle is the best Pokeman, because it is electric", Rating = 5,
                                Reviewer = new Reviewer(){ Name = "Teddy", LastName = "Smith" } },
                                new Review { Title= "Squirtle",Text = "Squirtle is the best a killing rocks", Rating = 5,
                                Reviewer = new Reviewer(){ Name = "Taylor", LastName = "Jones" } },
                                new Review { Title= "Squirtle", Text = "squirtle, squirtle, squirtle", Rating = 1,
                                Reviewer = new Reviewer(){ Name = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Harry",
                            LastName = "Potter",
                            Gym = "Mistys Gym",
                            Country = new Country()
                            {
                                Name = "Saffron City"
                            }
                        }
                    },
                                    new PokemanOwner()
                                    {
                        Pokeman = new Pokeman()
                        {
                            Name = "Venasuar",
                            BirthDate = new DateTime(1903,1,1),
                            PokemanCategories = new List<PokemanCategory>()
                            {
                                new PokemanCategory { Category = new Category() { Name = "Leaf"}}
                            },
                            Reviews = new List<Review>()
                            {
                                new Review { Title="Veasaur",Text = "Venasuar is the best Pokeman, because it is electric", Rating = 5,
                                Reviewer = new Reviewer(){ Name = "Teddy", LastName = "Smith" } },
                                new Review { Title="Veasaur",Text = "Venasuar is the best a killing rocks", Rating = 5,
                                Reviewer = new Reviewer(){ Name = "Taylor", LastName = "Jones" } },
                                new Review { Title="Veasaur",Text = "Venasuar, Venasuar, Venasuar", Rating = 1,
                                Reviewer = new Reviewer(){ Name = "Jessica", LastName = "McGregor" } },
                            }
                        },
                        Owner = new Owner()
                        {
                            Name = "Ash",
                            LastName = "Ketchum",
                            Gym = "Ashs Gym",
                            Country = new Country()
                            {
                                Name = "Millet Town"
                            }
                        }
                    }
                };
                dataContext.PokemanOwners.AddRange(PokemanOwners);
                dataContext.SaveChanges();
            }
        }
    }
}
