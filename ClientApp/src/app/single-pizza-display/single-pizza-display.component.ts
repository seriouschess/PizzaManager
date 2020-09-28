
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IngredientDto, PizzaDto, PizzaService } from '../api';
import { ValidatorService } from '../validator.service';

@Component({
  selector: 'app-single-pizza-display',
  templateUrl: './single-pizza-display.component.html',
  styleUrls: ['./single-pizza-display.component.css']
})
export class SinglePizzaDisplayComponent implements OnInit {

  constructor(private _apiClient:PizzaService, private _validator:ValidatorService) { }

  @Input() pizza:PizzaDto;
  @Output() pizza_updated = new EventEmitter<boolean>();
  all_ingredients:IngredientDto[];
  all_unused_ingredients:IngredientDto[];
  update_mode:boolean;
  pizza_to_update:PizzaDto;

  //validation fields
  valid_name:boolean;
  valid_dough:boolean;

  ngOnInit(): void {
    this.valid_name = false;
    this.valid_dough = false;
    this.update_mode = false;
    this.fetchIngredients();
  }

  addIngredientToPizza(pizza_id:number, ingredient_id:number){
    this._apiClient.pizzaAddToppingToPizza(pizza_id, ingredient_id).subscribe(res =>{
      this.pizza = res;
      this.getUnusedIngredients();
    });
  }

  removeIngredientFromPizza(pizza_id:number, ingredient_id:number){
    this._apiClient.pizzaRemoveToppingFromPizza(pizza_id, ingredient_id).subscribe(res =>{
      this.pizza = res;
      this.getUnusedIngredients();
    });
  }

  fetchIngredients(){
    this._apiClient.pizzaGetIngredients().subscribe((res) =>{
      this.all_ingredients = res
      this.getUnusedIngredients();
    });
  }

  getUnusedIngredients(){
    this.all_unused_ingredients = [];
    var pizza_ingredient_strings:string[] = this.getPizzaIngredientsAsString(this.pizza.ingredients);
    for( var x=0; x<this.all_ingredients.length ;x++ ){
      let i = this.all_ingredients[x];
      console.log("try: "+i.ingredient_id);
      if( pizza_ingredient_strings.includes(i.ingredient_name) ){
        console.log("success: "+i.ingredient_id);
      }else{
        console.log("fail: "+i.ingredient_id);
        this.all_unused_ingredients.push(i);
      }
    }
  }
  getPizzaIngredientsAsString(pizza_ingredients:IngredientDto[]){
    var output:string[] = [];
    for(var x:number=0; x<pizza_ingredients.length ;x++){
      output.push(pizza_ingredients[x].ingredient_name);
    }
    return output;
  }

  toggleUpdateUI(){
    this.refreshPizzaToUpdate();
    this.update_mode = !this.update_mode;
  }

  refreshPizzaToUpdate(){
    this.pizza_to_update = {
      pizza_id: this.pizza.pizza_id,
      name: this.pizza.name,
      pizza_dough_type: this.pizza.pizza_dough_type,
      is_calzone: this.pizza.is_calzone
    }
  }

  updatePizzaInformation(){
    this.valid_name = this._validator.validateString(this.pizza_to_update.name);
    this.valid_dough = this._validator.validateString(this.pizza_to_update.pizza_dough_type);
    if(this.valid_name && this.valid_dough){
      this._apiClient.pizzaUpdatePizza( this.pizza_to_update ).subscribe(res => {
        this.pizza = res;
        this.toggleUpdateUI();
        this.pizza_updated.emit(true);
      });
    }
  }
}
