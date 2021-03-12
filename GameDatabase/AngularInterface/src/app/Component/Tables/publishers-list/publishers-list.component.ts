import { AfterViewInit, Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges, ViewChild } from '@angular/core';
import { MatDialog, MatPaginator, MatSort } from '@angular/material';
import { ConfirmationDialogComponent } from '../../../components/shared/confirmation-dialog/confirmation-dialog.component';
import { Publisher } from '../../../Models/Publisher';
import { PublishersServiceService } from '../../publishers/services/publishers-service.service';
import { PublishersListDataSource } from './publishers-list-datasource';

@Component({
  selector: 'app-publishers-list-table',
  templateUrl: './publishers-list.component.html',
  styleUrls: ['./publishers-list.component.css']
})
export class PublishersListTableComponent implements AfterViewInit, OnChanges, OnInit {

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: PublishersListDataSource;
  @Input() data: Publisher[];
  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['id', 'name', "Actions"];
  selectedRowId: number;
  @Output() selection: EventEmitter<Publisher> = new EventEmitter<Publisher>();
  pageIndex: number = 0;
  pageSize: number = 25;

  constructor(private publisherService: PublishersServiceService, public dialog: MatDialog) {

  }

  ngOnInit(): void {
    this.publisherService.getAll(this.pageIndex, this.pageSize).subscribe(result => {
      debugger;
      this.data = result;
      this.dataSource = new PublishersListDataSource(this.paginator, this.sort, this.data);
    });
  }

  ngAfterViewInit() {
    this.dataSource = new PublishersListDataSource(this.paginator, this.sort, this.data);
  }

  ngOnChanges(changes: SimpleChanges): void {
    //this.dataSource = new PublishersListDataSource(this.paginator, this.sort, this.data);
  }

  getServerData(event) {
    debugger;
    this.publisherService.getAll(this.pageIndex, this.pageSize).subscribe(result => {
      debugger;
      this.data = result;
      this.dataSource = new PublishersListDataSource(this.paginator, this.sort, this.data);
    });
  }

  getRecord(row) {
    debugger;
    this.selectedRowId = row.id;
    this.selection.emit(row);
  }

  openDialog(row): void {
    debugger;
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      width: '350px',
      data: "Do you confirm the deletion of this data?"
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        console.log('Yes clicked');
        // DO SOMETHING
      }
    });
  }
}
