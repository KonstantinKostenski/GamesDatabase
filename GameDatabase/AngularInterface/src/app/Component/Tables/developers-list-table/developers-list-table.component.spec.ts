import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MatPaginatorModule } from '@angular/material/paginator/paginator-module'
import { DevelopersListTableComponent } from './developers-list-table.component';

describe('DevelopersListComponent', () => {
  let component: DevelopersListTableComponent;
  let fixture: ComponentFixture<DevelopersListTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [DevelopersListTableComponent ],
      imports: [
        NoopAnimationsModule,
        MatPaginatorModule,
        MatSortModule,
        MatTableModule,
      ]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DevelopersListTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should compile', () => {
    expect(component).toBeTruthy();
  });
});
