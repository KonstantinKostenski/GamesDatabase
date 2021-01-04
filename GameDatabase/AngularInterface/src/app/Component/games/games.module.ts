import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GamesListComponent } from './games-list/games-list.component';
import { GameDefinitionlisComponent } from './game-definitionlis/game-definitionlis.component';
import { MaterialModule } from '../../material/material.module';
import { TablesModule } from '../Tables/tables/tables.module';
import { AddGamePopUpComponent } from './add-game-pop-up/add-game-pop-up.component';

@NgModule({
  declarations: [GamesListComponent, GameDefinitionlisComponent, AddGamePopUpComponent],
  imports: [
    CommonModule,
    TablesModule,
    MaterialModule
  ]
})
export class GamesModule { }
