import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MatPaginatorModule, MatSortModule, MatTableModule } from '@angular/material';

import { DevelopersListTableComponent } from './developers-list.component';

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
