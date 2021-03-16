import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GameDefinitionlisComponent } from './game-definitionlis.component';

describe('GameDefinitionlisComponent', () => {
  let component: GameDefinitionlisComponent;
  let fixture: ComponentFixture<GameDefinitionlisComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GameDefinitionlisComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GameDefinitionlisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
