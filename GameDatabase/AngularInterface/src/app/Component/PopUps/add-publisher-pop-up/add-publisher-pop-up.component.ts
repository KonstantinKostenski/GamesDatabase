import { Component, Inject, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { Publisher } from "../../../Models/Publisher";
import { CommonServiceService } from "../../Services/common-service.service";


@Component({
  selector: 'app-add-publisher-pop-up',
  templateUrl: './add-publisher-pop-up.component.html',
  styleUrls: ['./add-publisher-pop-up.component.css']
})
export class AddPublisherPopUpComponent implements OnInit {

  addPublisherForm: FormGroup;
  publisher: Publisher;
  constructor(private formBuilder: FormBuilder, public dialogRef: MatDialogRef<AddPublisherPopUpComponent>, public commonService: CommonServiceService, @Inject(MAT_DIALOG_DATA) public data: Publisher) {
    if (data) {
      this.publisher = data;
    }
  }

  ngOnInit() {
    if (!this.publisher) {
      this.publisher = new Publisher();
    }

    this.addPublisherForm = this.formBuilder.group({
      name: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      description: [null, [Validators.required, Validators.minLength(10), Validators.maxLength(250)]],
      location: [null, [Validators.required, Validators.minLength(3), Validators.maxLength(30)]],
      logoUrl: [null, [Validators.required]]
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
