import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import {RegisterUserModel } from '../../../Models/user';
import { UsersService } from '../users.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerUserForm: FormGroup;
  user: RegisterUserModel;

  constructor(private formBuilder: FormBuilder, private userService: UsersService) { }

  ngOnInit() {
    this.user = new RegisterUserModel();
    this.registerUserForm = this.formBuilder.group({
      firstName: [null, Validators.required],
      lastName: [null, Validators.required],
      username: [null, Validators.required],
      password: [null, Validators.required],
      repeatPassword: [null, Validators.required]
    }, { validator: matchingFieldsValidation("password", "repeatPassword")});
    this.registerUserForm.patchValue(this.user);
  }

  submit() {
    debugger;
    if (!this.registerUserForm.valid) {
      return;
    }

    this.user = this.registerUserForm.getRawValue();

    this.userService.register(this.user).subscribe(result => {

    });

    //this.dialogRef.close(this.registerUserForm.getRawValue());
  }

}

export function matchingFieldsValidation(password: string, repeatPassword: string) {
  return (control: AbstractControl): { [key: string]: any } => {
    debugger;
    const firstControl = control.get(password);
    const secondControl = control.get(repeatPassword);
    if (!firstControl || !secondControl) return null;
    return firstControl.value != secondControl.value ? { matchingFields: true } : null;
  }
}
