import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { Game } from '../../../Models/Game';
import { ButtonsService } from '../../Buttons/buttons.service';
import { GameDefinitionlisComponent } from '../../games/game-definition/game-definitionlis.component';
import { GamesServiceService } from '../../games/services/games-service.service';
import { AddGamePopUpComponent } from '../../PopUps/add-game-pop-up/add-game-pop-up.component';
import { CommonServiceService } from '../../Services/common-service.service';
import { ConfirmationDialogComponent } from '../../shared/confirmation-dialog/confirmation-dialog.component';
import { GamesListDataSource } from './games-list-datasource';
import { MatPaginator, PageEvent } from '@angular/material/paginator'
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-games-list-table',
  templateUrl: './games-list.component.html',
  styleUrls: ['./games-list.component.css']
})
export class GamesListTableComponent implements  OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: GamesListDataSource;
  data: Game[];
  @Output() selection: EventEmitter<Game> = new EventEmitter<Game>();
  pageEvent: PageEvent;
  pageIndex: number = 0;
  pageSize: number = 25;
  selectedRowId: number;
  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['Id', 'Name', 'ReleaseDate', 'Platform', 'DeveloperName', 'PublisherName', 'Actions', 'FavouriteGame'];
  currentSelection: Game;
  @Input() isFavourites: boolean = false;

  constructor(private gamesService: GamesServiceService, public dialog: MatDialog, private commonService: CommonServiceService, private buttonsService: ButtonsService) {

  }

  ngOnInit(): void {
    debugger;
    this.favouriteGame.bind(this);
    this.gamesService.getAllGames(this.pageIndex, this.pageSize, this.isFavourites).subscribe(result => {
      debugger;
      this.data = result;
      this.addNewDatasource();
    }, error => {
      debugger;
        this.commonService.handleError([error], error.status);
    });
  }

  addNewDatasource() {
    this.dataSource = new GamesListDataSource(this.paginator, this.sort, this.data);
  }

  getServerData(event) {
    debugger;
    this.gamesService.getAllGames(event.pageIndex, event.pageSize, this.isFavourites).subscribe(result => {
      debugger;
      this.data = result;
    }, error => {
      debugger;
        this.commonService.handleError([error], error.status);
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

  openDialogDetails(row) {
    const dialogRef = this.dialog.open(GameDefinitionlisComponent, {
      width: '1000px',
      data: row.id
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        console.log('Yes clicked');
        // DO SOMETHING
      }
    });
  }

  favouriteGame(row) {
    debugger;
    this.currentSelection = this.data.find(item => item.id === this.selectedRowId);
    this.currentSelection.isFavouritedByUser = !this.currentSelection.isFavouritedByUser;
    this.buttonsService.favouriteGame(row.id, this.commonService.parseJwt(localStorage.getItem("token")).id, this.currentSelection.isFavouritedByUser).subscribe(result => {
      debugger;
      this.addNewDatasource();
      this.currentSelection = null;
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
        this.addNewDatasource();
      });
    });
  }
}
