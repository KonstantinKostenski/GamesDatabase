import { CommonModule } from '@angular/common';

import { MaterialModule } from '../../../Material/material.module';
import { SharedModule } from '../../Shared/shared.module';
import { SearchGamesPanelComponent } from '../search-games-panel/search-games-panel.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { GamesListTableComponent } from '../games-list-table/games-list-table.component';
import { DevelopersListTableComponent } from '../developers-list-table/developers-list-table.component';
import { PublishersListTableComponent } from '../publishers-list/publishers-list-table.component';
import { FavouritesListTableComponent } from '../favourites-list-table/favourites-list-table.component';


@NgModule({
  declarations: [
    GamesListTableComponent,
    DevelopersListTableComponent,
    PublishersListTableComponent,
    FavouritesListTableComponent,
    SearchGamesPanelComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    SharedModule,
     FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    GamesListTableComponent,
    DevelopersListTableComponent,
    PublishersListTableComponent,
    FavouritesListTableComponent,
    SearchGamesPanelComponent
  ]
})
export class TablesModule { }
