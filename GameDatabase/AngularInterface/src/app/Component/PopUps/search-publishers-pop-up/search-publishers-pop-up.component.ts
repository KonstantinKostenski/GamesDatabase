import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { Search } from '../../../Models/Publisher';

@Component({
  selector: 'app-search-publishers-pop-up',
  templateUrl: './search-publishers-pop-up.component.html',
  styleUrls: ['./search-publishers-pop-up.component.css']
})
export class SearchPublishersPopUpComponent implements OnInit {

  searchPublishersForm: FormGroup;
  searchObject: Search;


  constructor(private formBuilder: FormBuilder, public dialogRef: MatDialogRef<SearchPublishersPopUpComponent>) { }

  ngOnInit() {
    this.searchObject = new Search();
    this.searchPublishersForm = this.formBuilder.group({
      name: [null, Validators.required]
    });
    this.searchPublishersForm.patchValue(this.searchObject);
  }

  submit() {
    if (!this.searchPublishersForm.valid) {
      return;
    }

    this.dialogRef.close(this.searchPublishersForm.getRawValue());
  }
}
