import { AfterViewInit, Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges, ViewChild } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { Publisher } from "../../../Models/Publisher";
import { AddPublisherPopUpComponent } from "../../PopUps/add-publisher-pop-up/add-publisher-pop-up.component";
import { PublishersServiceService } from "../../Publishers/services/publishers-service.service";
import { CommonServiceService } from "../../Services/common-service.service";
import { ConfirmationDialogComponent } from "../../Shared/confirmation-dialog/confirmation-dialog.component";
import { PublishersListDataSource } from "./publishers-list-table-datasource";

@Component({
  selector: 'app-publishers-list-table',
  templateUrl: './publishers-list-table.component.html',
  styleUrls: ['./publishers-list-table.component.css']
})
export class PublishersListTableComponent implements AfterViewInit, OnChanges, OnInit {

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  pageEvent: PageEvent;
  dataSource: PublishersListDataSource;
  @Input() data: Publisher[];
  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['id', 'name', "Actions"];
  selectedRowId: number;
  @Output() selection: EventEmitter<Publisher> = new EventEmitter<Publisher>();
  pageIndex: number = 0;
  pageSize: number = 25;
    currentSelection: Publisher;

  constructor(private publisherService: PublishersServiceService, public dialog: MatDialog, private commonService: CommonServiceService) {

  }

  ngOnInit(): void {
    this.publisherService.getAll(this.pageIndex, this.pageSize).subscribe(result => {
      debugger;
      this.data = result;
      this.dataSource = new PublishersListDataSource(this.paginator, this.sort, this.data);
    }, error => {
      debugger;
        this.commonService.handleError([error], error.status);
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
    }, error => {
      debugger;
        this.commonService.handleError([error], error.status);
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

  openDialogEdit(row) {
    debugger;
    this.currentSelection = this.data.find(item => item.id === this.selectedRowId);
    const dialogRef = this.dialog.open(AddPublisherPopUpComponent, {
      width: '350px',
      data: this.currentSelection
    });

    dialogRef.afterClosed().subscribe(result => {
      debugger;
      // DO SOMETHING
      this.publisherService.update({ ...this.currentSelection, ...result }).subscribe(result => {
        debugger;
        Object.assign(this.currentSelection, result);
        this.currentSelection = null;
        //this.dataSource = new DevelopersListDataSource(this.paginator, this.sort, this.data);
      });
    });
  }
}
