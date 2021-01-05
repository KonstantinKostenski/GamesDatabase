import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Search } from '../../../Models/Developer';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-search-developers-pop-up',
  templateUrl: './search-developers-pop-up.component.html',
  styleUrls: ['./search-developers-pop-up.component.css']
})
export class SearchDevelopersPopUpComponent implements OnInit {
  searchDeveloperForm: FormGroup;
  searchObject: Search;


  constructor(private formBuilder: FormBuilder, public dialogRef: MatDialogRef<SearchDevelopersPopUpComponent>) { }

  ngOnInit() {
    this.searchObject = new Search();
    this.searchDeveloperForm = this.formBuilder.group({
      name: [null, Validators.required]
    });
    this.searchDeveloperForm.patchValue(this.searchObject);
  }

  submit() {
    if (!this.searchDeveloperForm.valid) {
      return;
    }

    this.dialogRef.close(this.searchDeveloperForm.getRawValue());
  }

}
