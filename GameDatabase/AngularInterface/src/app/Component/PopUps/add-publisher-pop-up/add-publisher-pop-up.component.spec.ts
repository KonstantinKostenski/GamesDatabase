import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPublisherPopUpComponent } from './add-publisher-pop-up.component';

describe('AddPublisherPopUpComponent', () => {
  let component: AddPublisherPopUpComponent;
  let fixture: ComponentFixture<AddPublisherPopUpComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddPublisherPopUpComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddPublisherPopUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
