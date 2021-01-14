import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FavouriteGameButtonComponent } from './favourite-game-button/favourite-game-button.component';
import { MaterialModule } from '../../material/material.module';

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
