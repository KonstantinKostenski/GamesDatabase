import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchGamesPanelComponent } from './search-games-panel.component';

describe('SearchGamesPanelComponent', () => {
  let component: SearchGamesPanelComponent;
  let fixture: ComponentFixture<SearchGamesPanelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SearchGamesPanelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchGamesPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
