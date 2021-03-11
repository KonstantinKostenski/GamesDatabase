import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Publisher } from '../../../Models/Publisher';
import { MatDialogRef } from '@angular/material';
import { CommonServiceService } from '../../Services/common-service.service';

@Component({
  selector: 'app-add-publisher-pop-up',
  templateUrl: './add-publisher-pop-up.component.html',
  styleUrls: ['./add-publisher-pop-up.component.css']
})
export class AddPublisherPopUpComponent implements OnInit {

  addPublisherForm: FormGroup;
  publisher: Publisher;
  constructor(private formBuilder: FormBuilder, public dialogRef: MatDialogRef<AddPublisherPopUpComponent>, private commonService: CommonServiceService) {

  }

  ngOnInit() {
    this.publisher = new Publisher();
    this.addPublisherForm = this.formBuilder.group({
      name: [null, Validators.required],
      description: [null, Validators.required],
      location: [null, Validators.required],
      logoUrl: [null, Validators.required]
    });
    this.addPublisherForm.patchValue(this.publisher);
  }

  submit() {
    if (!this.addPublisherForm.valid) {
      return;
    }

    this.dialogRef.close(this.addPublisherForm.getRawValue());
  }
}
