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

  all_pizzas: PizzaDto[];

  ngOnInit(): void {
    this.updateDashboard();
  }

  updateDashboard(){
    this._apiClient.pizzaGetAllPizzas().subscribe((res) =>
    this.all_pizzas = res);
  }
}
