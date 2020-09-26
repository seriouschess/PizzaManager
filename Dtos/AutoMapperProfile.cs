using AutoMapper;
using PizzaManager.Models;

namespace PizzaManager.Dtos
{
    public class AutoMapperProfile : Profile  
    {  
        public AutoMapperProfile()  
        {  
            CreateMap<PizzaDto, Pizza>();  
            CreateMap<Pizza, PizzaDto>(); 
            CreateMap<NewPizzaDto, Pizza>();
            CreateMap<Ingredient, IngredientDto>(); 
        }  
    }  
}