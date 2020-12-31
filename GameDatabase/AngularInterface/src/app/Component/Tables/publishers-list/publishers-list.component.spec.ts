import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MatPaginatorModule, MatSortModule, MatTableModule } from '@angular/material';

import { PublishersListTableComponent } from './publishers-list.component';

describe('PublishersListComponent', () => {
  let component: PublishersListTableComponent;
  let fixture: ComponentFixture<PublishersListTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PublishersListTableComponent ],
      imports: [
        NoopAnimationsModule,
        MatPaginatorModule,
        MatSortModule,
        MatTableModule,
      ]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PublishersListTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should compile', () => {
    expect(component).toBeTruthy();
  });
});
