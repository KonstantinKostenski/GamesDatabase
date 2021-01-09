import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DeveloperListComponent } from './developer-list/developer-list.component';
import { DeveloperDefinitionComponent } from './developer-definition/developer-definition.component';
import { MaterialModule } from '../../material/material.module';

@NgModule({
  declarations: [DeveloperListComponent, DeveloperDefinitionComponent],
  imports: [
    CommonModule,
    MaterialModule
  ]
})
export class DevelopersModule { }
