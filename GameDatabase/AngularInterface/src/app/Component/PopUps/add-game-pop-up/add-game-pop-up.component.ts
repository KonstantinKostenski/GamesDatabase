import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Game } from '../../../Models/Game';
import { MatDialogRef, MatDialog } from '@angular/material';
import { SearchDevelopersPopUpComponent } from '../search-developers-pop-up/search-developers-pop-up.component';
import { SearchPublishersPopUpComponent } from '../search-publishers-pop-up/search-publishers-pop-up.component';
import { SelectListItem } from '../../../Models/SelectListItem';
import { CommonServiceService } from '../../Services/common-service.service';

@Component({
  selector: 'app-add-game-pop-up',
  templateUrl: './add-game-pop-up.component.html',
  styleUrls: ['./add-game-pop-up.component.css']
})
export class AddGamePopUpComponent implements OnInit {

  addGameForm: FormGroup;
  game: Game;
  genres: SelectListItem[] = [];

  constructor(private formBuilder: FormBuilder, public dialogRef: MatDialogRef<AddGamePopUpComponent>, public dialog: MatDialog, private commonService: CommonServiceService) { }

  ngOnInit() {
    debugger;
    this.game = new Game();
    this.commonService.getGenres().subscribe(result => {
      debugger;
      this.genres = result;
    });

    this.addGameForm = this.formBuilder.group({
      name: [null, Validators.required, Validators.min(3), Validators.max(50)],
      description: [null, Validators.required, Validators.min(10), Validators.max(250)],
      releaseDate: [null, Validators.required],
      genreId: [null, Validators.required],
      publisherName: [null, Validators.required],
      developerName: [null, Validators.required],
      platform: [null, Validators.required],
      coverArtUrl: [null, Validators.required],
    });
    this.addGameForm.patchValue(this.game);
  }

  getErrorMessage(control: any) {
    debugger;
    return control.hasError('required') ? 'You must enter a value' :
      control.hasError('minlength') ? 'Required length is at least 3 characters' :
        control.hasError('maxlength') ? 'Required length is at least 50 characters' :

          '';
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
        this.game.developerName = result.name;
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
        this.game.publisherName = result.name;
        this.addGameForm.patchValue(this.game);
      }
    });
  }

  submit() {
    debugger;
    if (!this.addGameForm.valid) {
      return;
    }
    this.dialogRef.close(this.addGameForm.getRawValue());
  }
}
