using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaManager.Models;

namespace PizzaManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        private static readonly string[] Topings = new[]
        {
            "Spinach", "Mushrooms", "Green Pepper", "Saussage", "Peperoni"
        };

        private readonly ILogger<PizzaController> _logger;
        private MemoryDatabaseContext dbContext;
        public PizzaController(ILogger<PizzaController> logger, MemoryDatabaseContext _dbContext)
        {
            dbContext = _dbContext;
            _logger = logger;
        }

        [HttpGet]
        public List<Pizza> GetAllPizzas()
        {
           return dbContext.Pizzas.ToList();
        }

        [HttpPost]
        public List<Pizza> AddPizza([FromBody] Pizza new_pizza){
            dbContext.Add(new_pizza);
            dbContext.SaveChanges();
            return dbContext.Pizzas.ToList();
        }
    }
}
