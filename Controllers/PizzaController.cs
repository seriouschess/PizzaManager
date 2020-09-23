using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaManager.Dtos;
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
        private MemoryDatabaseContext _dbContext;
        private readonly IMapper _mapper; 
        public PizzaController(ILogger<PizzaController> logger, MemoryDatabaseContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet]
        public List<Pizza> GetAllPizzas()
        {
           return _dbContext.Pizzas.ToList();
        }

        [HttpPost]
        public List<PizzaDto> AddPizza([FromBody] Pizza new_pizza){
            _dbContext.Add(new_pizza);
            _dbContext.SaveChanges();
            List<Pizza> all_pizzas = _dbContext.Pizzas.ToList();
            List<PizzaDto> all_safe_pizzas = new List<PizzaDto>();
            foreach(Pizza pizza in all_pizzas){
                all_safe_pizzas.Add( _mapper.Map<PizzaDto>(pizza) );
            }
            return all_safe_pizzas;
        }
    }
}
