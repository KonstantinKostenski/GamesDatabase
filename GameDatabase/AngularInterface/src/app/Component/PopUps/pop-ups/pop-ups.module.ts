import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../../../material/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { AddGamePopUpComponent } from '../add-game-pop-up/add-game-pop-up.component';
import { SearchDevelopersPopUpComponent } from '../search-developers-pop-up/search-developers-pop-up.component';
import { SearchPublishersPopUpComponent } from '../search-publishers-pop-up/search-publishers-pop-up.component';
import { TablesModule } from '../../Tables/tables/tables.module';
import { AddPublisherPopUpComponent } from '../add-publisher-pop-up/add-publisher-pop-up.component';
import { AddDeveloperPopUpComponent } from '../add-developer-pop-up/add-developer-pop-up.component';

@NgModule({
  declarations: [
    AddGamePopUpComponent,
    AddPublisherPopUpComponent,
    AddDeveloperPopUpComponent,
    SearchDevelopersPopUpComponent,
    SearchPublishersPopUpComponent,
  ],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
    TablesModule

  ],
  exports: [
    AddGamePopUpComponent,
    AddPublisherPopUpComponent,
    AddDeveloperPopUpComponent,
    SearchDevelopersPopUpComponent,
    SearchPublishersPopUpComponent
  ]
})
export class PopUpsModule { }
