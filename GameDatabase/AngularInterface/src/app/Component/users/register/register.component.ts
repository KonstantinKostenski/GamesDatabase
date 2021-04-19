import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import {RegisterUserModel } from '../../../Models/User';
import { CommonServiceService } from '../../Services/common-service.service';
import { UsersService } from '../users.service';

export function matchingFieldsValidation(password: string, repeatPassword: string) {
  return (control: AbstractControl): { [key: string]: any } => {
    const firstControl = control.get(password);
    const secondControl = control.get(repeatPassword);
    if (!firstControl || !secondControl) return null;
    return firstControl.value !== secondControl.value ? { matchingFields: true } : null;
  }
}

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerUserForm: FormGroup;
  user: RegisterUserModel;

  constructor(private formBuilder: FormBuilder, private userService: UsersService, private router: Router, public commonService: CommonServiceService) { }

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
      debugger;
      this.router.navigateByUrl("/");
    });

    //this.dialogRef.close(this.registerUserForm.getRawValue());
  }

}


