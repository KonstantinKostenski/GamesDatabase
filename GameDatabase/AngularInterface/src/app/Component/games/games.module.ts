import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GamesListComponent } from './games-list/games-list.component';
import { GameDefinitionlisComponent } from './game-definitionlis/game-definitionlis.component';
import { MaterialModule } from '../../material/material.module';
import { TablesModule } from '../Tables/tables/tables.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PopUpsModule } from '../PopUps/pop-ups/pop-ups.module';
import { FavouritesListComponent } from './favourites-list/favourites-list.component';

@NgModule({
  declarations: [GamesListComponent, GameDefinitionlisComponent, FavouritesListComponent],
  imports: [
    CommonModule,
    TablesModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    PopUpsModule
  ]
})
export class GamesModule { }
