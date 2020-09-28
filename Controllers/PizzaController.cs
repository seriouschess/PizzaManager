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
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
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

            //get pizzas
            List<Pizza> all_pizzas = _dbQueries.GetAllPizzas();

            //format dto
            List<PizzaDto> all_pizza_dtos = new List<PizzaDto>();
            foreach(Pizza pizza in all_pizzas){
                PizzaDto pizza_dto = _mapper.Map<PizzaDto>(pizza);
                List<Ingredient> ingredients = _dbQueries.GetIngredientForPizza(pizza.pizza_id);
                List<IngredientDto> ingredient_dtos = new List<IngredientDto>();
                foreach(Ingredient ingredient in ingredients){
                    ingredient_dtos.Add(_mapper.Map<IngredientDto>(ingredient));
                }
                pizza_dto.ingredients = ingredient_dtos;
                all_pizza_dtos.Add( pizza_dto );
            }
            return all_pizza_dtos;
        }

        [HttpGet]
        [Route("one/{pizza_id}")]
        public PizzaDto GetOnePizza( int pizza_id ){

            //get pizza
            Pizza found_pizza = _dbQueries.GetPizzaById( pizza_id );

            //format pizza dto
            PizzaDto found_pizza_dto = _mapper.Map<PizzaDto>(found_pizza);
            List<Ingredient> ingredients = _dbQueries.GetIngredientForPizza(pizza_id);

            //convert each ingredient to ingredient dto
            List<IngredientDto> ingredient_dtos = new List<IngredientDto>();
            foreach(Ingredient ingredient in ingredients){
                ingredient_dtos.Add(_mapper.Map<IngredientDto>(ingredient));
            }

            found_pizza_dto.ingredients = ingredient_dtos;
            return found_pizza_dto;
        }

        [HttpPut]
        public PizzaDto UpdatePizza([FromBody] PizzaDto updated_pizza){
            Pizza update_confirmation = _dbQueries.UpdatePizza( _mapper.Map<Pizza>(updated_pizza) );
            return _mapper.Map<PizzaDto>(GetOnePizza(update_confirmation.pizza_id));
        }

        [HttpDelete]
        [Route("delete/{pizza_id}")]
        public PizzaDto DeletePizza(int pizza_id){
            Pizza deleted_pizza = _dbQueries.DeletePizzaById(pizza_id);
            return _mapper.Map<PizzaDto>(deleted_pizza);
        }

        [HttpPost]
        public PizzaDto AddPizza([FromBody] NewPizzaDto new_pizza_dto){
            Pizza new_pizza = _mapper.Map<Pizza>(new_pizza_dto);
            _dbQueries.AddNewPizza( new_pizza );
            return GetOnePizza( new_pizza.pizza_id );
        }


        //ingredient and topping related queries:

        [HttpGet]
        [Route("ingredients")]
        public List<IngredientDto> GetIngredients(){
            //get ingredients
            List<Ingredient> ingredients = _dbQueries.GetAllIngreidnets();

            //format dto object list
            List<IngredientDto> ingredient_dtos = new List<IngredientDto>();
            foreach(Ingredient ing in ingredients){
                ingredient_dtos.Add(_mapper.Map<IngredientDto>(ing));
            }
            return ingredient_dtos;
        }

        [HttpPost]
        [Route("topping/add/{pizza_id}/{ingredient_id}")]
        public PizzaDto AddToppingToPizza(int pizza_id, int ingredient_id){
            Pizza modified_pizza = _dbQueries.AddToppingToPizza(pizza_id, ingredient_id);
            return GetOnePizza(pizza_id);
        }

        [HttpDelete]
        [Route("topping/delete/{pizza_id}/{ingredient_id}")]
        public PizzaDto RemoveToppingFromPizza(int pizza_id, int ingredient_id){
            Ingredient test_ingredient = _dbQueries.GetIngredientById(ingredient_id);
            _dbQueries.DeleteToppingFromPizza(pizza_id, ingredient_id);
            PizzaDto return_pizza = GetOnePizza(pizza_id);
            return return_pizza;
        }
    }
}
