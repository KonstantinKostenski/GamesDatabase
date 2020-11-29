import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DeveloperDefinitionComponent } from './developer-definition.component';

describe('DeveloperDefinitionComponent', () => {
  let component: DeveloperDefinitionComponent;
  let fixture: ComponentFixture<DeveloperDefinitionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DeveloperDefinitionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeveloperDefinitionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
