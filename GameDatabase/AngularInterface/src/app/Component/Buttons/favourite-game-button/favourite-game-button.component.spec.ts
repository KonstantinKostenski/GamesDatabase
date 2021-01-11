import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FavouriteGameButtonComponent } from './favourite-game-button.component';

describe('FavouriteGameButtonComponent', () => {
  let component: FavouriteGameButtonComponent;
  let fixture: ComponentFixture<FavouriteGameButtonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FavouriteGameButtonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FavouriteGameButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
