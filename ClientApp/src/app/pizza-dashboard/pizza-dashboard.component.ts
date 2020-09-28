import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PizzaDto, PizzaService } from '../api';

@Component({
  selector: 'app-pizza-dashboard',
  templateUrl: './pizza-dashboard.component.html',
  styleUrls: ['./pizza-dashboard.component.css']
})
export class PizzaDashboardComponent implements OnInit {

  constructor(private _apiClient:PizzaService) { }

  @Input() all_pizzas:PizzaDto[];
  @Output() update_dashboard = new EventEmitter<boolean>();
  @Output() dashboard_pizza_selected = new EventEmitter<boolean>();
  detailed_view:boolean;
  selected_pizza:PizzaDto;

  ngOnInit(): void {
    this.detailed_view = false;
    this.selected_pizza = null;
  }

  updateDashboard(){
    this.update_dashboard.emit(true);
  }

  toggleDetailedView(){
    this.detailed_view = !this.detailed_view;
  }

  getSelectedPizza( pizza_id:number ){
    this.dashboard_pizza_selected.emit(true);
    this._apiClient.pizzaGetOnePizza(pizza_id).subscribe(res => {
      this.selected_pizza = res;
    });
  }

  deleteSelectedPizza( pizza_id:number ){
    this._apiClient.pizzaDeletePizza(pizza_id).subscribe(res => {
      console.log("Deleted Pizza");
      console.log(res);
      this.update_dashboard.emit(true);
    });
  }

  deselectPizza(){
    this.selected_pizza = null;
  }

}
