using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaManager.Models
{
    public class Pizza
    {
        [Key]
        public int pizza_id {get;set;}
        public string pizza_dough_type {get;set;}
        public bool is_calzone {get;set;}
    }
}