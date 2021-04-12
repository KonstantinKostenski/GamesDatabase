import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Game } from '../../../Models/Game';
import { MatDialogRef, MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SearchDevelopersPopUpComponent } from '../search-developers-pop-up/search-developers-pop-up.component';
import { SearchPublishersPopUpComponent } from '../search-publishers-pop-up/search-publishers-pop-up.component';
import { SelectListItem } from '../../../Models/SelectListItem';
import { CommonServiceService } from '../../Services/common-service.service';
import { ImageSnippet } from '../../../Models/ImageSnippet';
import { FileUploadServiceService } from '../../Services/file-upload-service.service';

@Component({
  selector: 'app-add-game-pop-up',
  templateUrl: './add-game-pop-up.component.html',
  styleUrls: ['./add-game-pop-up.component.css']
})
export class AddGamePopUpComponent implements OnInit {

  addGameForm: FormGroup;
  game: Game;
  genres: SelectListItem[] = [];
    selectedFile: ImageSnippet;

  constructor(private formBuilder: FormBuilder, public dialogRef: MatDialogRef<AddGamePopUpComponent>, public dialog: MatDialog, private commonService: CommonServiceService, private imageService: FileUploadServiceService, @Inject(MAT_DIALOG_DATA) public data: Game) {
    if (this.data) {
      this.game = data;
    }
  }

  ngOnInit() {
    debugger;
    if (!this.game) {
      this.game = new Game();
    }
    this.commonService.getGenres().subscribe(result => {
      debugger;
      this.genres = result;
      this.setValues();
    });

    this.addGameForm = this.formBuilder.group({
      name: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      description: [null, [Validators.required, Validators.minLength(10), Validators.maxLength(250)]],
      releaseDate: [null, Validators.required],
      genreId: [null, Validators.required],
      publisherName: [null, Validators.required],
      developerName: [null, Validators.required],
      platform: [null, Validators.required],
      file: [null, Validators.required],
    });

    this.addGameForm.patchValue(this.game);
  }

  setValues() {
    this.addGameForm.patchValue({
      genreId: this.game.genreId,
    });
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

  onFileChange(event) {
    debugger;
    const file: File = event.files[0];
    const reader = new FileReader();

    reader.addEventListener('load', (event: any) => {
      debugger;
      this.selectedFile = new ImageSnippet(event.target.result, file);

      //this.imageService.uploadImage(this.selectedFile.file).subscribe(
      //  (res) => {

      //  },
      //  (err) => {

      //  })
    });

    reader.readAsDataURL(file);
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
    this.game.coverArtUrl = this.selectedFile.src;
    this.dialogRef.close({ ...this.game, ...this.addGameForm.getRawValue() });
  }
}
