import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GamesListComponent } from './games-list/games-list.component';
import { GameDefinitionlisComponent } from './game-definitionlis/game-definitionlis.component';

@NgModule({
  declarations: [GamesListComponent, GameDefinitionlisComponent],
  imports: [
    CommonModule
  ]
})
export class GamesModule { }
