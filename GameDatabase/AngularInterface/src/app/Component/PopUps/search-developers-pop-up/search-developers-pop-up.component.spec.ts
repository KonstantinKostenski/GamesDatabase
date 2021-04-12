import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { SearchDevelopersPopUpComponent } from './search-developers-pop-up.component';

describe('SearchDevelopersPopUpComponent', () => {
  let component: SearchDevelopersPopUpComponent;
  let fixture: ComponentFixture<SearchDevelopersPopUpComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SearchDevelopersPopUpComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchDevelopersPopUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
