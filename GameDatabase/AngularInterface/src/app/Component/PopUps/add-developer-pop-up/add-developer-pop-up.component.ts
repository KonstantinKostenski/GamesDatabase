import { Component, Inject, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { Developer } from "../../../Models/Developer";
import { CommonServiceService } from "../../Services/common-service.service";


@Component({
  selector: 'app-add-developer-pop-up',
  templateUrl: './add-developer-pop-up.component.html',
  styleUrls: ['./add-developer-pop-up.component.css']
})
export class AddDeveloperPopUpComponent implements OnInit {

  addDeveloperForm: FormGroup;
  developer: Developer;

  constructor(private formBuilder: FormBuilder, public dialogRef: MatDialogRef<AddDeveloperPopUpComponent>, public commonService: CommonServiceService, @Inject(MAT_DIALOG_DATA) public data: Developer) {
    if (data) {
      this.developer = data;
    }
  }

  ngOnInit() {
    if (!this.developer) {
      this.developer = new Developer();
    }

    this.addDeveloperForm = this.formBuilder.group({
      name: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      description: [null, [Validators.required, Validators.minLength(10), Validators.maxLength(250)]],
      location: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(30)]],
      logoUrl: [null, Validators.required]
    });

    this.addDeveloperForm.patchValue(this.developer);
  }


  submit() {
    debugger;
    if (!this.addDeveloperForm.valid) {
      return;
    }

    this.dialogRef.close(this.addDeveloperForm.getRawValue());
  }
}
