import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchDevelopersPanelComponent } from './search-developers-panel.component';

describe('SearchDevelopersPanelComponent', () => {
  let component: SearchDevelopersPanelComponent;
  let fixture: ComponentFixture<SearchDevelopersPanelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SearchDevelopersPanelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchDevelopersPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
