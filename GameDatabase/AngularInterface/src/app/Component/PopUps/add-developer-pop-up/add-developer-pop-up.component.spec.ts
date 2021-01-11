import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddDeveloperPopUpComponent } from './add-developer-pop-up.component';

describe('AddDeveloperPopUpComponent', () => {
  let component: AddDeveloperPopUpComponent;
  let fixture: ComponentFixture<AddDeveloperPopUpComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddDeveloperPopUpComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddDeveloperPopUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
