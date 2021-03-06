import { CommonModule } from '@angular/common';
import { LogInComponent } from './log-in/log-in.component';
import { RegisterComponent } from './register/register.component';
import { UsersListComponent } from './users-list/users-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../../Material/material.module';
import { PopUpsModule } from '../PopUps/pop-ups/pop-ups.module';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [ LogInComponent, RegisterComponent, UsersListComponent],
  imports: [
    CommonModule,  FormsModule,
    ReactiveFormsModule,
    PopUpsModule, MaterialModule, RouterModule
  ],
  exports: [LogInComponent, RegisterComponent, UsersListComponent]
})
export class UsersModule { }
