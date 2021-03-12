import { AfterViewInit, Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges, ViewChild } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { Developer } from '../../../Models/Developer';
import { DevelopersServiceService } from '../../Developers/services/developers-service.service';
import { DevelopersListDataSource } from './developers-list-datasource';

@Component({
  selector: 'app-developers-list-table',
  templateUrl: './developers-list.component.html',
  styleUrls: ['./developers-list.component.css']
})
export class DevelopersListTableComponent implements AfterViewInit, OnChanges, OnInit {

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: DevelopersListDataSource;
  selectionMade: boolean;
  @Input() data: Developer[];
  @Output() selection: EventEmitter<Developer> = new EventEmitter<Developer>();
  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['id', 'name'];
  selectedRowId: number;
  pageIndex: number = 0;
  pageSize: number = 25;

  constructor(private developersService: DevelopersServiceService) {

  }

  ngOnInit(): void {
    this.developersService.getAll(this.pageIndex, this.pageSize).subscribe(result => {
      this.data = result;
      this.dataSource = new DevelopersListDataSource(this.paginator, this.sort, this.data);
    });
  }

  ngAfterViewInit() {
    debugger;

  }

  getServerData(event) {
    debugger;
    this.developersService.getAll(this.pageIndex, this.pageSize).subscribe(result => {
      this.data = result;
      this.dataSource = new DevelopersListDataSource(this.paginator, this.sort, this.data);
    });
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
