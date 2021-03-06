import { CommonModule } from '@angular/common';
import { PublishersListComponent } from './publishers-list/publishers-list.component';
import { PublisherDefinitionComponent } from './publisher-definition/publisher-definition.component';
import { MaterialModule } from '../../Material/material.module';
import { TablesModule } from '../Tables/tables/tables.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PopUpsModule } from '../PopUps/pop-ups/pop-ups.module';
import { SearchPublishersComponentComponent } from './search-publishers-component/search-publishers-component.component';
import { NgModule } from '@angular/core';

@NgModule({
  declarations: [PublishersListComponent, PublisherDefinitionComponent, SearchPublishersComponentComponent],
  imports: [
    CommonModule,
    TablesModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    PopUpsModule
  ]
})
export class PublishersModule { }
