import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { Search } from '../../../Models/Game';
import {PublisherSearch, Publisher } from '../../../Models/Publisher';
import { PublishersServiceService } from '../../publishers/services/publishers-service.service';

@Component({
  selector: 'app-search-publishers-pop-up',
  templateUrl: './search-publishers-pop-up.component.html',
  styleUrls: ['./search-publishers-pop-up.component.css']
})
export class SearchPublishersPopUpComponent implements OnInit {

  searchPublishersForm: FormGroup;
  searchObject: PublisherSearch;
  data: Publisher[];
  selectedPublisher: Publisher;
  shouldShowGrid: boolean;

  constructor(private formBuilder: FormBuilder, public dialogRef: MatDialogRef<SearchPublishersPopUpComponent>, private publisherService: PublishersServiceService) { }

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

    this.publisherService.search(this.searchPublishersForm.getRawValue()).subscribe(result => {
      debugger;
      this.shouldShowGrid = true;
      this.data = result;
      //this.dialogRef.close(result);

    })

  }

  recieveResult(result) {
    debugger;
    this.selectedPublisher = result;
  }

  chooseFromGrid() {
    debugger;
    if (this.selectedPublisher) {
      this.data = null;
      this.shouldShowGrid = false;
      this.dialogRef.close(this.selectedPublisher);
    }
  }
}
