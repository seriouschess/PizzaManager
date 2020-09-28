using System.Collections.Generic;
using PizzaManager.Models;
using System.Linq;
using System;

namespace PizzaManager.BusinessLogic
{
    public class Queries
    {
        private MemoryDatabaseContext _dbContext;
        public Queries(MemoryDatabaseContext dbContext){
            _dbContext = dbContext;
        }

        //Pizza Queries

        public List<Pizza> GetAllPizzas(){
            return _dbContext.Pizzas.ToList();
        }

        public Pizza GetPizzaById( int pizza_id ){
            List<Pizza> found_pizzas = _dbContext.Pizzas.Where(x => x.pizza_id == pizza_id).ToList();
            if( found_pizzas.Count != 1 ){
                throw new System.ArgumentException($"Pizza id: {pizza_id} not found.");
            }else{
                return found_pizzas[0];
            }
        }

        public List<Pizza> SearchPizzasByName(string pizza_name){
            return _dbContext.Pizzas.Where(x => x.name == pizza_name).ToList(); 
        }

        public Pizza AddNewPizza(Pizza new_pizza){
            new_pizza.pizza_id = 0;
            _dbContext.Add(new_pizza);
            _dbContext.SaveChanges();
            return GetPizzaById(new_pizza.pizza_id);
        }

        public Pizza UpdatePizza(Pizza updated_pizza){
            Pizza subject_pizza = GetPizzaById(updated_pizza.pizza_id);

            if( updated_pizza.name != null ){
                subject_pizza.name = updated_pizza.name;
            }
            if( updated_pizza.pizza_dough_type != null ){
                subject_pizza.pizza_dough_type = updated_pizza.pizza_dough_type;
            }

            subject_pizza.is_calzone = updated_pizza.is_calzone; //always pass back boolean

            subject_pizza.UpdatedAt = DateTime.Now;

            _dbContext.SaveChanges();
            return subject_pizza;
        }

        public Pizza DeletePizzaById( int pizza_id ){
            Pizza Zombie = GetPizzaById( pizza_id );
            _dbContext.Remove(Zombie);
            _dbContext.SaveChanges();
            return Zombie;
        }

        //Pizza Ingredient Queries
        public Ingredient AddIngredient(string ingredient_name){
            Ingredient new_ingredient = new Ingredient();
            new_ingredient.ingredient_name = ingredient_name;
            _dbContext.Add(new_ingredient);
            _dbContext.SaveChanges();
            return new_ingredient;
        }

        public Ingredient GetIngredientById(int ingredient_id){
            List<Ingredient> found_ingredients = _dbContext.Ingredients.Where(x => x.ingredient_id == ingredient_id).ToList();
            if( found_ingredients.Count != 1 ){
                throw new System.ArgumentException($"Ingredient id: {ingredient_id} not found.");
            }else{
                return found_ingredients[0];
            }
        }

        public List<Ingredient> GetIngredientForPizzaAsStringList( int pizza_id ){

            //can return empty list
            List<Ingredient> ingredients = new List<Ingredient>();
            List<PizzaTopping> toppings = _dbContext.PizzaToppings.Where(x => x.pizza_id == pizza_id).ToList();

            foreach(PizzaTopping topping in toppings){
                Ingredient found_ingredient = GetIngredientById( topping.ingredient_id );
                ingredients.Add(found_ingredient);
            }

            return ingredients;
        }

        public List<Ingredient> GetAllIngreidnets(){
            return _dbContext.Ingredients.ToList();
        }

        //Pizza Topping Queries

        public Pizza AddToppingToPizza(int pizza_id, int ingredient_id ){

            //check for valid db items
            Pizza involved_pizza = GetPizzaById(pizza_id);
            GetIngredientById(ingredient_id);

            List<PizzaTopping> found_toppings = _dbContext.PizzaToppings.Where( x => x.pizza_id == pizza_id).Where(y => y.ingredient_id == ingredient_id).ToList();
            if( found_toppings.Count == 0 ){

                //add topping association
                PizzaTopping new_topping = new PizzaTopping();
                new_topping.pizza_id = pizza_id;
                new_topping.ingredient_id = ingredient_id;
                _dbContext.Add(new_topping);
                _dbContext.SaveChanges();
            }else if( found_toppings.Count == 1 ){
                //nothing
            }else{
                //should never happen
                throw new System.Exception($"Pizza ID {pizza_id} has two or more of the same ingredient topping.");
            }

            return involved_pizza;
        }

        public void DeleteToppingFromPizza( int pizza_id, int ingredient_id ){
            List<PizzaTopping> found_toppings = _dbContext.PizzaToppings.Where( x => x.pizza_id == pizza_id).Where(y => y.ingredient_id == ingredient_id).ToList();
            if(found_toppings.Count != 0){
                _dbContext.PizzaToppings.Remove(found_toppings[0]);
                _dbContext.SaveChanges();  
            }
        }
    }
}