using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaManager.BusinessLogic;
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
        private Queries _dbQueries;
        private readonly IMapper _mapper; 
        public PizzaController(ILogger<PizzaController> logger, MemoryDatabaseContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbQueries = new Queries(dbContext);
            _logger = logger;
        }

        [HttpGet]
        public List<PizzaDto> GetAllPizzas()
        {
            List<Pizza> all_pizzas = _dbQueries.GetAllPizzas();
            List<PizzaDto> all_pizza_dtos = new List<PizzaDto>();
            foreach(Pizza pizza in all_pizzas){
                all_pizza_dtos.Add( _mapper.Map<PizzaDto>(pizza) );
            }
            return all_pizza_dtos;
        }

        [HttpGet]
        [Route("one/{pizza_id}")]
        public PizzaDto GetOnePizza( int pizza_id ){
            Pizza found_pizza = _dbQueries.GetPizzaById( pizza_id );
            return _mapper.Map<PizzaDto>(found_pizza);
        }

        [HttpPut]
        public PizzaDto UpdatePizza([FromBody] PizzaDto updated_pizza){
            Pizza update_confirmation = _dbQueries.UpdatePizza( _mapper.Map<Pizza>(updated_pizza) );
            return _mapper.Map<PizzaDto>(update_confirmation);
        }

        [HttpPost]
        public List<PizzaDto> AddPizza([FromBody] Pizza new_pizza){
            _dbQueries.AddNewPizza(new_pizza);
            List<Pizza> all_pizzas = _dbQueries.GetAllPizzas();
            List<PizzaDto> all_safe_pizzas = new List<PizzaDto>();
            foreach(Pizza pizza in all_pizzas){
                all_safe_pizzas.Add( _mapper.Map<PizzaDto>(pizza) );
            }
            return all_safe_pizzas;
        }

        [HttpGet]
        [Route("ingredients")]
        public List<Ingredient> GetUniqueIngredientsArray(){
            return _dbQueries.GetAllIngreidnets();
        }

        // [HttpGet]
        // [Route("topping/add/{pizza_id}/{ingredient_id}")]
        // public PizzaDto AddToppingToPizza(int pizza_id, int ingredient_id){
        //     _dbQueries.AddToppingToPizza()
        //     return 
        // }
    }
}
