import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MatPaginatorModule, MatSortModule, MatTableModule } from '@angular/material';

import { FavouritesListTableComponent } from './favourites-list.component';

describe('FavouritesListComponent', () => {
  let component: FavouritesListTableComponent;
  let fixture: ComponentFixture<FavouritesListTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [FavouritesListTableComponent ],
      imports: [
        NoopAnimationsModule,
        MatPaginatorModule,
        MatSortModule,
        MatTableModule,
      ]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FavouritesListTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should compile', () => {
    expect(component).toBeTruthy();
  });
});
