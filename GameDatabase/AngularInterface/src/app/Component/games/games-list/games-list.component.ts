import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { AddGamePopUpComponent } from '../../PopUps/add-game-pop-up/add-game-pop-up.component';
import { GamesListItem } from '../../Tables/games-list/games-list-datasource';
import { GamesServiceService } from '../services/games-service.service';

@Component({
  selector: 'app-games-list',
  templateUrl: './games-list.component.html',
  styleUrls: ['./games-list.component.css']
})
export class GamesListComponent implements OnInit {

  constructor(private gamesService: GamesServiceService, public dialog: MatDialog) { }

  ngOnInit() {
    
  }
  openDialog(): void {
    debugger;
    const dialogRef = this.dialog.open(AddGamePopUpComponent, {
      width: '350px',
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.gamesService.saveNewGame(result);
      }
    });
  }

}
