import { CommonModule } from '@angular/common';
import { GamesListTableComponent } from '../games-list/games-list.component';
import { DevelopersListTableComponent } from '../developers-list/developers-list.component';
import { PublishersListTableComponent } from '../publishers-list/publishers-list.component';
import { FavouritesListTableComponent } from '../favourites-list/favourites-list.component';
import { MaterialModule } from '../../../material/material.module';
import { SharedModule } from '../../Shared/shared.module';
import { SearchGamesPanelComponent } from '../search-games-panel/search-games-panel.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';


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
