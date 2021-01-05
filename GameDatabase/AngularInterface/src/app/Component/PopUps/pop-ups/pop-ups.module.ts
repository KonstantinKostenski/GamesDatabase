import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../../../material/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { AddGamePopUpComponent } from '../add-game-pop-up/add-game-pop-up.component';
import { SearchDevelopersPopUpComponent } from '../search-developers-pop-up/search-developers-pop-up.component';
import { SearchPublishersPopUpComponent } from '../search-publishers-pop-up/search-publishers-pop-up.component';

@NgModule({
  declarations: [AddGamePopUpComponent, SearchDevelopersPopUpComponent, SearchPublishersPopUpComponent],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule
  ],
  exports: [
    AddGamePopUpComponent, SearchDevelopersPopUpComponent, SearchPublishersPopUpComponent
  ]
})
export class PopUpsModule { }
