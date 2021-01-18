import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { User } from '../../../Models/user';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerUserForm: FormGroup;
  user: User;

  constructor(private formBuilder: FormBuilder, public dialogRef: MatDialogRef<RegisterComponent>) { }

  ngOnInit() {
    this.user = new User();
    this.registerUserForm = this.formBuilder.group({
      name: [null, Validators.required],
      password: [null, Validators.required],
      repeatPassword: [null, Validators.required]
    });
    this.registerUserForm.patchValue(this.user);
  }


  submit() {
    if (!this.registerUserForm.valid) {
      return;
    }

    this.dialogRef.close(this.registerUserForm.getRawValue());
  }

}
