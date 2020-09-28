import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SinglePizzaDisplayComponent } from './single-pizza-display.component';

describe('SinglePizzaDisplayComponent', () => {
  let component: SinglePizzaDisplayComponent;
  let fixture: ComponentFixture<SinglePizzaDisplayComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SinglePizzaDisplayComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SinglePizzaDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
