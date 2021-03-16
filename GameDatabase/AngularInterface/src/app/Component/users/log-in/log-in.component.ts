import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { LoginUserModel } from '../../../Models/user';
import { MatDialogRef } from '@angular/material';
import { UsersService } from '../users.service';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {
  logInForm: FormGroup;
  user: LoginUserModel;
    error: any;

  constructor(private formBuilder: FormBuilder, private userService: UsersService) { }

  ngOnInit() {
    this.user = new LoginUserModel();
    this.logInForm = this.formBuilder.group({
      username: [null, Validators.required],
      password: [null, Validators.required],
    });
    this.logInForm.patchValue(this.user);
  }


  submit() {
    debugger;
    if (!this.logInForm.valid) {
      return;
    }

    this.userService.authenticate(this.logInForm.getRawValue()).subscribe(result => {
      debugger;
      localStorage.setItem("token", result.token);
      this.error = null;
      
    }, error => {
        debugger;
        this.error = error.error.message;
    });
    //this.dialogRef.close(this.logInForm.getRawValue());
  }
}
