import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PublisherDefinitionComponent } from './publisher-definition.component';

describe('PublisherDefinitionComponent', () => {
  let component: PublisherDefinitionComponent;
  let fixture: ComponentFixture<PublisherDefinitionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PublisherDefinitionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PublisherDefinitionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
