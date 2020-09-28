import { JsonPipe } from '@angular/common';
import { Injectable } from '@angular/core';
import { stringify } from 'querystring';

@Injectable({
  providedIn: 'root'
})
export class ValidatorService {

  minimum_string_length:number;
  maximum_string_length:number;

  constructor() {
    this.maximum_string_length = 30;
    this.minimum_string_length = 2;
  }


  validateString(test_string:string){
    let errors:number = 0;

    if( test_string.length > this.maximum_string_length ){
      errors  += 1;
    }

    if( test_string.length < this.minimum_string_length ){
      errors += 1;
    }

    if(errors > 0){
      return false;
    }else{
      return true;
    }
  }
}
