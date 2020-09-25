using Microsoft.EntityFrameworkCore;

namespace PizzaManager.Models
{
    public class MemoryDatabaseContext:DbContext
    {
        public MemoryDatabaseContext(DbContextOptions<MemoryDatabaseContext> options)
        : base(options) { }

        public DbSet<Pizza> Pizzas {get;set;}

        public DbSet<Ingredient> Ingredients {get;set;}

        public DbSet<PizzaTopping> PizzaToppings {get;set;}  
    }
}