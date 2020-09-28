import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { NewPizzaDto, PizzaService } from '../api';

@Component({
  selector: 'app-add-pizza',
  templateUrl: './add-pizza.component.html',
  styleUrls: ['./add-pizza.component.css']
})
export class AddPizzaComponent implements OnInit {

  add_pizza_selected:boolean;
  pizza_to_add: NewPizzaDto;
  pizza_selected:boolean;
  @Output() pizza_added = new EventEmitter<boolean>();
  constructor(private _apiClient:PizzaService) { }

  ngOnInit(): void {
    this.refreshPizzaToAdd();
  }

  postNewPizza(){
    this._apiClient.pizzaAddPizza(this.pizza_to_add).subscribe((res) =>{
      this.toggleAddPizzaSelected();
      this.pizza_added.emit(true);
    });
  }

  toggleAddPizzaSelected(){
    this.refreshPizzaToAdd();
    this.add_pizza_selected = !this.add_pizza_selected;
  }

  refreshPizzaToAdd(){
    this.pizza_to_add = {
      name: "",
      pizza_dough_type: "",
      is_calzone: false
    }
  }

}
