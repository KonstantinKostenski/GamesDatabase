import { CommonModule } from '@angular/common';
import { DeveloperListComponent } from './developer-list/developer-list.component';
import { DeveloperDefinitionComponent } from './developer-definition/developer-definition.component';
import { MaterialModule } from '../../material/material.module';
import { TablesModule } from '../Tables/tables/tables.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PopUpsModule } from '../PopUps/pop-ups/pop-ups.module';
import { SearchDevelopersPanelComponent } from './search-developers-panel/search-developers-panel.component';
import { NgModule } from '@angular/core';

@NgModule({
  declarations: [DeveloperListComponent, DeveloperDefinitionComponent, SearchDevelopersPanelComponent],
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
