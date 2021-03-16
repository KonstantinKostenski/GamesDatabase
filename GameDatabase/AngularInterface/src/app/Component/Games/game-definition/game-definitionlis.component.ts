import { Component, OnInit } from '@angular/core';
import { Game } from '../../../Models/Game';
import { GamesServiceService } from '../services/games-service.service';

@Component({
  selector: 'app-game-definitionlis',
  templateUrl: './game-definitionlis.component.html',
  styleUrls: ['./game-definitionlis.component.css']
})
export class GameDefinitionlisComponent implements OnInit {
  game: Game;


  constructor(private gamesService: GamesServiceService) { }

  ngOnInit() {
  }

}
