
using System.Collections.Generic;

namespace PizzaManager.BusinessLogic
{
    public class DatabaseInitializer
    {
        private Queries _dbQueries;
        private List<string> _ingredients = IngredientsList.AllIngredients;

        public DatabaseInitializer(Queries dbQueries){
            _dbQueries = dbQueries;
        }

        public void InitializeIngredients(){
            foreach(string ingr in _ingredients){
                _dbQueries.AddIngredient(ingr);
            }
        }
    }
}