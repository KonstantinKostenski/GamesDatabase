import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LogInComponent } from './log-in/log-in.component';
import { RegisterComponent } from './register/register.component';
import { UsersListComponent } from './users-list/users-list.component';

@NgModule({
  declarations: [ LogInComponent, RegisterComponent, UsersListComponent],
  imports: [
    CommonModule
  ]
})
export class UsersModule { }
