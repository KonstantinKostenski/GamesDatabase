import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchPublishersComponentComponent } from './search-publishers-component.component';

describe('SearchPublishersComponentComponent', () => {
  let component: SearchPublishersComponentComponent;
  let fixture: ComponentFixture<SearchPublishersComponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SearchPublishersComponentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchPublishersComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
