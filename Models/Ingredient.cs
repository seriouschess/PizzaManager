using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaManager.Models
{
    public class Ingredient
    {
        [Key]
        public int ingredient_id {get;set;}
        public string ingredient_name {get;set;}
        public List<PizzaTopping> pizza_toppings {get;set;}
    }
}