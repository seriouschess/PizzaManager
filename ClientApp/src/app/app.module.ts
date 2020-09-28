import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

//api dependencies
import { ApiModule } from './api';
import { HttpClientModule } from '@angular/common/http';
import { SinglePizzaDisplayComponent } from './single-pizza-display/single-pizza-display.component';
import { PizzaDashboardComponent } from './pizza-dashboard/pizza-dashboard.component';
import { AddPizzaComponent } from './add-pizza/add-pizza.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PageNotFoundComponent,
    SinglePizzaDisplayComponent,
    PizzaDashboardComponent,
    AddPizzaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ApiModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
