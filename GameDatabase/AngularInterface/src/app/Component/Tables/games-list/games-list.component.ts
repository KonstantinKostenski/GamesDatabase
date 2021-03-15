import { AfterViewInit, ChangeDetectorRef, Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatDialog, MatPaginator, MatSort, PageEvent } from '@angular/material';
import { ConfirmationDialogComponent } from '../../../components/shared/confirmation-dialog/confirmation-dialog.component';
import { Developer } from '../../../Models/Developer';
import { GamesServiceService } from '../../games/services/games-service.service';
import { AddGamePopUpComponent } from '../../PopUps/add-game-pop-up/add-game-pop-up.component';
import { GamesListDataSource, GamesListItem } from './games-list-datasource';

@Component({
  selector: 'app-games-list-table',
  templateUrl: './games-list.component.html',
  styleUrls: ['./games-list.component.css']
})
export class GamesListTableComponent implements AfterViewInit, OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: GamesListDataSource;
  data: GamesListItem[];
  @Output() selection: EventEmitter<GamesListItem> = new EventEmitter<GamesListItem>();
  pageEvent: PageEvent;
  pageIndex: number = 0;
  pageSize: number = 25;
  selectedRowId: number;
  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['Id', 'Name', 'ReleaseDate', 'Platform', 'Developer', 'Publisher', 'Actions'];
    currentSelection: GamesListItem;

  constructor(private gamesService: GamesServiceService, private cd: ChangeDetectorRef, public dialog: MatDialog) {

  }

  ngOnInit(): void {
    debugger;
    this.gamesService.getAllGames(this.pageIndex, this.pageSize).subscribe(result => {
      debugger;
      this.data = result;
      this.dataSource = new GamesListDataSource(this.paginator, this.sort, this.data);
    });
  }

  ngAfterViewInit() {
  }

  getServerData(event) {
    debugger;
    this.gamesService.getAllGames(event.pageIndex, event.pageSize).subscribe(result => {
      debugger;
      this.data = result;
    });
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

  getRecord(row) {
    debugger;
    this.selectedRowId = row.id;
    this.selection.emit(row);
  }

  openDialogEdit(row) {
    debugger;
    this.currentSelection = this.data.find(item => item.id === this.selectedRowId);
    const dialogRef = this.dialog.open(AddGamePopUpComponent, {
      width: '350px',
      data: this.currentSelection
    });

    dialogRef.afterClosed().subscribe(result => {
      debugger;
      // DO SOMETHING
      this.gamesService.update({ ...this.currentSelection, ...result }, this.selectedRowId).subscribe(result => {
        debugger;
        Object.assign(this.currentSelection, result);
        this.currentSelection = null;
        //this.dataSource = new DevelopersListDataSource(this.paginator, this.sort, this.data);
      });
    });
  }
}
