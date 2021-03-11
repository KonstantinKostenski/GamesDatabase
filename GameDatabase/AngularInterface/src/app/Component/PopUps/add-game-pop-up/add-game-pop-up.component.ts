import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup, FormControl } from '@angular/forms';
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
      name: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      description: [null, [Validators.required, Validators.minLength(10), Validators.maxLength(250)]],
      releaseDate: [null, Validators.required],
      genreId: [null, Validators.required],
      publisherName: [null, Validators.required],
      developerName: [null, Validators.required],
      platform: [null, Validators.required],
      coverArtUrl: [null, Validators.required],
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
        this.game.developerName = result.name;
        this.game.developerId = result.id;
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
      debugger;
      if (result) {
        this.game.publisherName = result.name;
        this.game.publisherId = result.id;
        this.addGameForm.patchValue(this.game);
      }
    });
  }

  submit() {
    debugger;
    if (!this.addGameForm.valid) {
      return;
    }
    this.dialogRef.close({ ...this.game, ...this.addGameForm.getRawValue() });
  }
}
