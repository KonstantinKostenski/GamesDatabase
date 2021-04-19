import { CommonModule } from '@angular/common';
import { FavouriteGameButtonComponent } from './favourite-game-button/favourite-game-button.component';
import { MaterialModule } from '../../Material/material.module';
import { NgModule } from '@angular/core';

@NgModule({
  declarations: [FavouriteGameButtonComponent],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [
    FavouriteGameButtonComponent
  ]
})
export class ButtonsModule { }
