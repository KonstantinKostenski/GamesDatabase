import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../../../material/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { AddGamePopUpComponent } from '../add-game-pop-up/add-game-pop-up.component';

@NgModule({
  declarations: [AddGamePopUpComponent],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule
  ],
  exports: [
    AddGamePopUpComponent
  ]
})
export class PopUpsModule { }
