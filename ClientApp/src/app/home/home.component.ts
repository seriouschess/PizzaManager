import { identifierModuleUrl } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ApiModule, Configuration, ConfigurationParameters, Pizza, PizzaDto, PizzaService } from '../api';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private _apiClient:PizzaService) { }

  all_pizzas:any;

  ngOnInit(): void {
    var some_pizza:Pizza = {
      pizza_id: 0,
      pizza_dough_type: "Flatbread",
      is_calzone: false
    }
    this._apiClient.pizzaAddPizza(some_pizza).subscribe((res) =>
    this.all_pizzas = res);
  }

}
