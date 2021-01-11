import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Developer } from '../../../Models/Developer';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-add-developer-pop-up',
  templateUrl: './add-developer-pop-up.component.html',
  styleUrls: ['./add-developer-pop-up.component.css']
})
export class AddDeveloperPopUpComponent implements OnInit {

  addDeveloperForm: FormGroup;
  developer: Developer;
  constructor(private formBuilder: FormBuilder, public dialogRef: MatDialogRef<AddDeveloperPopUpComponent>,) {

  }

  ngOnInit() {
    this.developer = new Developer();
    this.addDeveloperForm = this.formBuilder.group({
      name: [null, Validators.required],
      description: [null, Validators.required],
      releaseDate: [null, Validators.required],
      genreId: [null, Validators.required],
      publisher: [null, Validators.required],
      developer: [null, Validators.required],
    });
    this.addDeveloperForm.patchValue(this.developer);
  }

  submit() {
    if (!this.addDeveloperForm.valid) {
      return;
    }

    this.dialogRef.close(this.addDeveloperForm.getRawValue());
  }
}
