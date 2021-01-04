import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Game } from '../../../Models/Game';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-add-game-pop-up',
  templateUrl: './add-game-pop-up.component.html',
  styleUrls: ['./add-game-pop-up.component.css']
})
export class AddGamePopUpComponent implements OnInit {

  addGameForm: FormGroup;
  game: Game;

  constructor(private formBuilder: FormBuilder, public dialogRef: MatDialogRef<AddGamePopUpComponent>) { }

  ngOnInit() {
    this.game = new Game();
    this.addGameForm = this.formBuilder.group({
      name: [null, Validators.required],
      description: [null, Validators.required],
      releaseDate: [null, Validators.required]
    });
    this.addGameForm.patchValue(this.game);
  }


  submit() {
    if (!this.addGameForm.valid) {
      return;
    }

    this.dialogRef.close(this.addGameForm.getRawValue());
  }
}
