import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPizzaComponent } from './add-pizza.component';

describe('AddPizzaComponent', () => {
  let component: AddPizzaComponent;
  let fixture: ComponentFixture<AddPizzaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddPizzaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddPizzaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
