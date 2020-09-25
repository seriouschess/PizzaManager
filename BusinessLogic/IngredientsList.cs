using System.Collections.Generic;

namespace PizzaManager.BusinessLogic
{
    public class IngredientsList
    {
        private static List<string> _AllIngredients = new List<string>(){"Spinach", "Mushrooms", "Peperoni", "Extra Cheese", "Pineapple", "Green Peppers", "Sausage"};
        public static List<string> AllIngredients{get;} = _AllIngredients;
    }
}