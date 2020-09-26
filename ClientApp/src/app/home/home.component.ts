import { identifierModuleUrl } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ApiModule, Configuration, ConfigurationParameters, NewPizzaDto, PizzaDto, PizzaService } from '../api';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private _apiClient:PizzaService) { }

  all_pizzas: any;
  pizza_to_add: NewPizzaDto;
  current_pizza: PizzaDto;

  ngOnInit(): void {
    this.pizza_to_add = {
      name: "",
      pizza_dough_type: "",
      is_calzone: false
    }
    this.getAllPizzas();
  }

  postNewPizza(){
    this._apiClient.pizzaAddPizza(this.pizza_to_add).subscribe((res) =>{
      this.current_pizza = res
      this.getAllPizzas();
    });
  }

  getAllPizzas(){
    this._apiClient.pizzaGetAllPizzas().subscribe((res) =>
    this.all_pizzas = res);
  }

  toggleCalzone(){
    this.pizza_to_add.is_calzone = !this.pizza_to_add.is_calzone;
  }

}
