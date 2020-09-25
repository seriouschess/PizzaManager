using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaManager.Models
{
    public class Pizza
    {
        [Key]
        public int pizza_id {get;set;}
        public string name {get;set;}
        public string pizza_dough_type {get;set;}
        public bool is_calzone {get;set;}
        public List<PizzaTopping> pizza_toppings {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        
    }
}