import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../../../Material/material.module';
import { TablesModule } from '../../Tables/tables/tables.module';
import { AddDeveloperPopUpComponent } from '../add-developer-pop-up/add-developer-pop-up.component';
import { AddGamePopUpComponent } from '../add-game-pop-up/add-game-pop-up.component';
import { AddPublisherPopUpComponent } from '../add-publisher-pop-up/add-publisher-pop-up.component';
import { ErrorPopUpComponent } from '../error-pop-up/error-pop-up.component';
import { SearchDevelopersPopUpComponent } from '../search-developers-pop-up/search-developers-pop-up.component';
import { SearchPublishersPopUpComponent } from '../search-publishers-pop-up/search-publishers-pop-up.component';


@NgModule({
  declarations: [
    ErrorPopUpComponent,
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
    ErrorPopUpComponent,
    AddGamePopUpComponent,
    AddPublisherPopUpComponent,
    AddDeveloperPopUpComponent,
    SearchDevelopersPopUpComponent,
    SearchPublishersPopUpComponent
  ]
})
export class PopUpsModule { }
