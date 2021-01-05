import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchPublishersPopUpComponent } from './search-publishers-pop-up.component';

describe('SearchPublishersPopUpComponent', () => {
  let component: SearchPublishersPopUpComponent;
  let fixture: ComponentFixture<SearchPublishersPopUpComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SearchPublishersPopUpComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchPublishersPopUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
