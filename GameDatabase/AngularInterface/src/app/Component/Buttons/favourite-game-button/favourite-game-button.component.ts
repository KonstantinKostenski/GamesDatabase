import { Component, OnInit } from '@angular/core';
import { Game } from '../../../Models/Game';

@Component({
  selector: 'app-favourite-game-button',
  templateUrl: './favourite-game-button.component.html',
  styleUrls: ['./favourite-game-button.component.css']
})
export class FavouriteGameButtonComponent implements OnInit {

  constructor() { }

  Game: Game = new Game();

  ngOnInit() {
  }

  addToFavourites() {

  }
}
