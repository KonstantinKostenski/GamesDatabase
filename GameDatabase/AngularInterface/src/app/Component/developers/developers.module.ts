import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DeveloperListComponent } from './developer-list/developer-list.component';
import { DeveloperDefinitionComponent } from './developer-definition/developer-definition.component';
import { MaterialModule } from '../../material/material.module';
import { TablesModule } from '../Tables/tables/tables.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PopUpsModule } from '../PopUps/pop-ups/pop-ups.module';

@NgModule({
  declarations: [DeveloperListComponent, DeveloperDefinitionComponent],
  imports: [
    CommonModule,
    TablesModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    PopUpsModule
  ]
})
export class DevelopersModule { }
