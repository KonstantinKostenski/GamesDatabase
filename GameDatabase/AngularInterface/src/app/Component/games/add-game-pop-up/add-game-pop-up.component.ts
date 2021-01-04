import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { GamesServiceService } from '../services/games-service.service';
import { Game } from '../../../Models/Game';

@Component({
  selector: 'app-add-game-pop-up',
  templateUrl: './add-game-pop-up.component.html',
  styleUrls: ['./add-game-pop-up.component.css']
})
export class AddGamePopUpComponent implements OnInit {

  loginForm: FormGroup;
  game: Game;

  constructor(private formBuilder: FormBuilder, private gamesService: GamesServiceService) { }

  ngOnInit() {
    this.game = new Game();
    this.loginForm = this.formBuilder.group({
      name: [null, Validators.required],
      definition: [null, Validators.required],
      releaseDate: [null, Validators.required]
    });
    this.loginForm.patchValue(this.game);
  }


  submit() {
    if (!this.loginForm.valid) {
      return;
    }


    console.log(this.loginForm.value);
  }
}
