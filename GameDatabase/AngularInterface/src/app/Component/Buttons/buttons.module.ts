import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FavouriteGameButtonComponent } from './favourite-game-button/favourite-game-button.component';

@NgModule({
  declarations: [FavouriteGameButtonComponent],
  imports: [
    CommonModule
  ],
  exports: [
    FavouriteGameButtonComponent
  ]
})
export class ButtonsModule { }
