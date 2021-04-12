import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator/paginator-module'
import { GamesListTableComponent } from './games-list.component';
import { MatTableModule } from '@angular/material/table';

describe('GamesListComponent', () => {
  let component: GamesListTableComponent;
  let fixture: ComponentFixture<GamesListTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [GamesListTableComponent ],
      imports: [
        NoopAnimationsModule,
        MatPaginatorModule,
        MatSortModule,
        MatTableModule,
      ]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GamesListTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should compile', () => {
    expect(component).toBeTruthy();
  });
});
