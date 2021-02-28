import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LogInComponent } from './log-in/log-in.component';
import { RegisterComponent } from './register/register.component';
import { UsersListComponent } from './users-list/users-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../../material/material.module';
import { PopUpsModule } from '../PopUps/pop-ups/pop-ups.module';

@NgModule({
  declarations: [ LogInComponent, RegisterComponent, UsersListComponent],
  imports: [
    CommonModule,  FormsModule,
    ReactiveFormsModule,
    PopUpsModule, MaterialModule
  ],
  exports: [LogInComponent, RegisterComponent, UsersListComponent]
})
export class UsersModule { }
