import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { NewPizzaDto, PizzaService } from '../api';
import { ValidatorService } from '../validator.service';

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
  valid_name:boolean;
  valid_dough:boolean;
  constructor(private _apiClient:PizzaService, private _validator:ValidatorService) { }

  ngOnInit(): void {
    this.valid_dough = true;
    this.valid_name = true;
    this.refreshPizzaToAdd();
  }

  postNewPizza(){
    this.valid_name = this._validator.validateString(this.pizza_to_add.name);
    this.valid_dough = this._validator.validateString(this.pizza_to_add.pizza_dough_type);
    if(this.valid_name && this.valid_dough){
      this._apiClient.pizzaAddPizza(this.pizza_to_add).subscribe((res) =>{
        this.toggleAddPizzaSelected();
        this.pizza_added.emit(true);
      });
    }
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
