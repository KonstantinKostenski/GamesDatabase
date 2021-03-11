import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder, FormControl } from '@angular/forms';
import { Developer } from '../../../Models/Developer';
import { MatDialogRef } from '@angular/material';
import { CommonServiceService } from '../../Services/common-service.service';

@Component({
  selector: 'app-add-developer-pop-up',
  templateUrl: './add-developer-pop-up.component.html',
  styleUrls: ['./add-developer-pop-up.component.css']
})
export class AddDeveloperPopUpComponent implements OnInit {

  addDeveloperForm: FormGroup;
  developer: Developer;

  constructor(private formBuilder: FormBuilder, public dialogRef: MatDialogRef<AddDeveloperPopUpComponent>, private commonService: CommonServiceService) {

  }

  ngOnInit() {
    this.developer = new Developer();

    this.addDeveloperForm = this.formBuilder.group({
      name: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      description: [null, [Validators.required, Validators.minLength(10), Validators.maxLength(250)]],
      location: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(30)]],
      logoUrl: [null, Validators.required]
    });

    this.addDeveloperForm.patchValue(this.developer);
    console.log(this.addDeveloperForm);
  }


  submit() {
    debugger;
    if (!this.addDeveloperForm.valid) {
      return;
    }

    this.dialogRef.close(this.addDeveloperForm.getRawValue());
  }
}
