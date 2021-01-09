import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Game } from '../../../Models/Game';
import { MatDialogRef, MatDialog } from '@angular/material';
import { SearchDevelopersPopUpComponent } from '../search-developers-pop-up/search-developers-pop-up.component';
import { SearchPublishersPopUpComponent } from '../search-publishers-pop-up/search-publishers-pop-up.component';

@Component({
  selector: 'app-add-game-pop-up',
  templateUrl: './add-game-pop-up.component.html',
  styleUrls: ['./add-game-pop-up.component.css']
})
export class AddGamePopUpComponent implements OnInit {

  addGameForm: FormGroup;
  game: Game;

  constructor(private formBuilder: FormBuilder, public dialogRef: MatDialogRef<AddGamePopUpComponent>, public dialog: MatDialog) { }

  ngOnInit() {
    this.game = new Game();
    this.addGameForm = this.formBuilder.group({
      name: [null, Validators.required],
      description: [null, Validators.required],
      releaseDate: [null, Validators.required],
      genreId: [null, Validators.required],
      publisher: [null, Validators.required],
      developer: [null, Validators.required],
    });
    this.addGameForm.patchValue(this.game);
  }


  openSearchDevelopers(): void {
    debugger;
    const dialogRef = this.dialog.open(SearchDevelopersPopUpComponent, {
      width: '350px',
    });
    dialogRef.afterClosed().subscribe(result => {
      debugger;
      if (result) {
        console.log(result);
        this.game.developer = result.name;
        this.addGameForm.patchValue(this.game);
      }
    });
  }

  openSearchPublishers(): void {
    debugger;
    const dialogRef = this.dialog.open(SearchPublishersPopUpComponent, {
      width: '350px',
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.addGameForm.patchValue(this.game);
      }
    });
  }

  submit() {
    if (!this.addGameForm.valid) {
      return;
    }

    this.dialogRef.close(this.addGameForm.getRawValue());
  }
}
