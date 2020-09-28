using System.Collections.Generic;

namespace PizzaManager.Dtos
{
    public class PizzaDto
    {
        public int pizza_id {get;set;}
        public string name {get;set;}
        public string pizza_dough_type {get;set;}
        public bool is_calzone {get;set;}
        public List<IngredientDto> ingredients {get;set;}
    }
}