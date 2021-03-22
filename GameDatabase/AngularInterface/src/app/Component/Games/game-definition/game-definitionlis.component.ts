import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { Game } from '../../../Models/Game';
import { GamesServiceService } from '../services/games-service.service';

@Component({
  selector: 'app-game-definitionlis',
  templateUrl: './game-definitionlis.component.html',
  styleUrls: ['./game-definitionlis.component.css']
})
export class GameDefinitionlisComponent implements OnInit {
  game: Game = new Game();


  constructor(private gamesService: GamesServiceService, @Inject(MAT_DIALOG_DATA) public id: number) { }

  ngOnInit() {
    this.gamesService.getGameById(this.id).subscribe(result => {
      this.game = result;
    });
  }

}
