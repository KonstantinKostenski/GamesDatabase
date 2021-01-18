import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { User } from '../../../Models/user';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {
  logInForm: FormGroup;
  user: User;

  constructor(private formBuilder: FormBuilder, public dialogRef: MatDialogRef<LogInComponent>) { }

  ngOnInit() {
    this.user = new User();
    this.logInForm = this.formBuilder.group({
      name: [null, Validators.required],
      password: [null, Validators.required],
    });
    this.logInForm.patchValue(this.user);
  }


  submit() {
    if (!this.logInForm.valid) {
      return;
    }

    this.dialogRef.close(this.logInForm.getRawValue());
  }
}
