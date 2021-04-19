import { CommonModule } from '@angular/common';
import { GamesListComponent } from './games-list/games-list.component';
import { TablesModule } from '../Tables/tables/tables.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PopUpsModule } from '../PopUps/pop-ups/pop-ups.module';
import { FavouritesListComponent } from './favourites-list/favourites-list.component';
import { GameDefinitionlisComponent } from './game-definition/game-definitionlis.component';
import { ButtonsModule } from '../Buttons/buttons.module';
import { NgModule } from '@angular/core';
import { MaterialModule } from '../../Material/material.module';

@NgModule({
  declarations: [GamesListComponent, GameDefinitionlisComponent, FavouritesListComponent],
  imports: [
    CommonModule,
    TablesModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    PopUpsModule,
    ButtonsModule
  ]
})
export class GamesModule { }
