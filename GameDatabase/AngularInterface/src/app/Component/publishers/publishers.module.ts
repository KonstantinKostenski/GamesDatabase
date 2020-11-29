import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PublishersListComponent } from './publishers-list/publishers-list.component';
import { PublisherDefinitionComponent } from './publisher-definition/publisher-definition.component';

@NgModule({
  declarations: [PublishersListComponent, PublisherDefinitionComponent],
  imports: [
    CommonModule
  ]
})
export class PublishersModule { }
