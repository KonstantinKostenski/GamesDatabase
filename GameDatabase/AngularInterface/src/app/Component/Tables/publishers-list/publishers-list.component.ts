import { AfterViewInit, Component, EventEmitter, Input, OnChanges, Output, SimpleChanges, ViewChild } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { Publisher } from '../../../Models/Publisher';
import { PublishersListDataSource } from './publishers-list-datasource';

@Component({
  selector: 'app-publishers-list-table',
  templateUrl: './publishers-list.component.html',
  styleUrls: ['./publishers-list.component.css']
})
export class PublishersListTableComponent implements AfterViewInit, OnChanges {
 
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: PublishersListDataSource;
  @Input() data: Publisher[];
  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['id', 'name'];
  selectedRowId: number;
  @Output() selection: EventEmitter<Publisher> = new EventEmitter<Publisher>();

  ngAfterViewInit() {
    this.dataSource = new PublishersListDataSource(this.paginator, this.sort, this.data);
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.dataSource = new PublishersListDataSource(this.paginator, this.sort, this.data);
  }

  getRecord(row) {
    debugger;
    this.selectedRowId = row.id;
    this.selection.emit(row);
  }
}
