import { AfterViewInit, Component, EventEmitter, Input, OnChanges, Output, SimpleChanges, ViewChild } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { Developer } from '../../../Models/Developer';
import { DevelopersListDataSource } from './developers-list-datasource';

@Component({
  selector: 'app-developers-list-table',
  templateUrl: './developers-list.component.html',
  styleUrls: ['./developers-list.component.css']
})
export class DevelopersListTableComponent implements AfterViewInit, OnChanges {
  
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: DevelopersListDataSource;
  selectionMade: boolean;
  @Input() data: Developer[];
  @Output() selection: EventEmitter<Developer> = new EventEmitter<Developer>();
  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['id', 'name'];
  selectedRowId: number;

  ngAfterViewInit() {
    debugger;
    console.log(this.data);
    this.dataSource = new DevelopersListDataSource(this.paginator, this.sort, this.data);
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.dataSource = new DevelopersListDataSource(this.paginator, this.sort, this.data);
  }

  getRecord(row) {
    debugger;
    this.selectedRowId = row.id;
    this.selection.emit(row);
  }
}
