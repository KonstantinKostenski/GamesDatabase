import { AfterViewInit, Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { Developer } from '../../../Models/Developer';
import { DevelopersServiceService } from '../../Developers/services/developers-service.service';
import { AddDeveloperPopUpComponent } from '../../PopUps/add-developer-pop-up/add-developer-pop-up.component';
import { CommonServiceService } from '../../Services/common-service.service';
import { ConfirmationDialogComponent } from '../../shared/confirmation-dialog/confirmation-dialog.component';
import { DevelopersListDataSource } from './developers-list-datasource';
import { MatPaginator, PageEvent } from '@angular/material/paginator'


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
  displayedColumns = ['id', 'name', "Actions"];
  selectedRowId: number;
  pageIndex: number = 0;
  pageSize: number = 25;
  currentSelection: Developer;
  pageEvent: PageEvent;


  constructor(private developersService: DevelopersServiceService, public dialog: MatDialog, private commonService: CommonServiceService) {

  }

  ngOnInit(): void {
    this.developersService.getAll(this.pageIndex, this.pageSize).subscribe(result => {
      this.data = result;
      this.changeDataSource();
    }, error => {
        debugger;
        this.commonService.handleError([error], error.status);
    });
  }

  ngAfterViewInit() {
    debugger;

  }

  changeDataSource() {
    this.dataSource = new DevelopersListDataSource(this.paginator, this.sort, this.data);

  }

  getServerData(event) {
    debugger;
    this.developersService.getAll(this.pageIndex, this.pageSize).subscribe(result => {
      this.data = result;
      this.changeDataSource();
    }, error => {
      debugger;
    });
  }

  ngOnChanges(_changes: SimpleChanges): void {
    this.changeDataSource();
  }

  getRecord(row) {
    debugger;
    this.selectedRowId = row.id;
    this.selection.emit(row);
  }

  openDialogDelete(row): void {
    debugger;


    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      width: '350px',
      data: "Do you confirm the deletion of this data?",
    });

    dialogRef.afterClosed().subscribe(result => {
      debugger;
      // DO SOMETHING
      this.developersService.delete(this.selectedRowId).subscribe(result => {
        debugger;
        this.data = this.data.filter(item => item.id !== result.id);
        this.changeDataSource();
      }, error => {
          this.commonService.handleError([error], error.status);
      });
    });
  }

  openDialogEdit(row) {
    debugger;
    this.currentSelection = this.data.find(item => item.id === this.selectedRowId);
    const dialogRef = this.dialog.open(AddDeveloperPopUpComponent, {
      width: '350px',
      data: this.currentSelection
    });

    dialogRef.afterClosed().subscribe(result => {
      debugger;
      // DO SOMETHING
      this.developersService.update({ ...this.currentSelection, ...result }).subscribe(result => {
        debugger;
        Object.assign(this.currentSelection, result);
        this.currentSelection = null;
        //this.dataSource = new DevelopersListDataSource(this.paginator, this.sort, this.data);
      });
    });
  }
}
