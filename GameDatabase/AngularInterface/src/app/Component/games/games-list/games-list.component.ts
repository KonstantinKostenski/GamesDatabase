import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { GamesListItem } from '../../Tables/games-list/games-list-datasource';
import { AddGamePopUpComponent } from '../add-game-pop-up/add-game-pop-up.component';
import { GamesServiceService } from '../services/games-service.service';

@Component({
  selector: 'app-games-list',
  templateUrl: './games-list.component.html',
  styleUrls: ['./games-list.component.css']
})
export class GamesListComponent implements OnInit {
  data: GamesListItem[];

  constructor(private gamesService: GamesServiceService, public dialog: MatDialog) { }

  ngOnInit() {
    this.gamesService.getAllGames().subscribe(result => {
      debugger;
      this.data = result;
    });
  }
  openDialog(): void {
    debugger;
    const dialogRef = this.dialog.open(AddGamePopUpComponent, {
      width: '350px',
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        console.log('Yes clicked');
        // DO SOMETHING
      }
    });
  }

}
