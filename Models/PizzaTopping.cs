using System.ComponentModel.DataAnnotations;

namespace PizzaManager.Models
{
    public class PizzaTopping
    {
        [Key]
        public int topping_id {get;set;}
        public int pizza_id {get;set;}
        public Pizza pizza {get;set;}
        public int ingredient_id {get;set;}
        public Ingredient ingredient {get;set;}
    }
}