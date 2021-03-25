import { Component, Input, OnInit } from '@angular/core';
import { Game } from '../../../Models/Game';
import { CommonServiceService } from '../../Services/common-service.service';
import { ButtonsService } from '../buttons.service';

@Component({
  selector: 'app-favourite-game-button',
  templateUrl: './favourite-game-button.component.html',
  styleUrls: ['./favourite-game-button.component.css']
})
export class FavouriteGameButtonComponent implements OnInit {

  constructor(private buttonsService: ButtonsService, private commonSerice: CommonServiceService) { }

  @Input() game: Game = new Game();

  ngOnInit() {
  }

  addToFavourites() {
    debugger;
    this.buttonsService.favouriteGame(this.game.id, this.commonSerice.parseJwt(localStorage.getItem("token")).id).subscribe(result => {
      debugger;
      this.game.isFavouritedByUser = true;

    });
  }
}
