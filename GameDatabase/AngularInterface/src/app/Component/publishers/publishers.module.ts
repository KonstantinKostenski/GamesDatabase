import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PublishersListComponent } from './publishers-list/publishers-list.component';
import { PublisherDefinitionComponent } from './publisher-definition/publisher-definition.component';
import { MaterialModule } from '../../material/material.module';
import { TablesModule } from '../Tables/tables/tables.module';

@NgModule({
  declarations: [PublishersListComponent, PublisherDefinitionComponent],
  imports: [
    CommonModule,
    MaterialModule,
    TablesModule
  ]
})
export class PublishersModule { }
