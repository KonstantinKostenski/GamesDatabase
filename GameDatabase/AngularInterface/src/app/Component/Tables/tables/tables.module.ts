import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GamesListTableComponent } from '../games-list/games-list.component';
import { DevelopersListTableComponent } from '../developers-list/developers-list.component';
import { PublishersListTableComponent } from '../publishers-list/publishers-list.component';
import { FavouritesListTableComponent } from '../favourites-list/favourites-list.component';
import { MaterialModule } from '../../../material/material.module';


@NgModule({
  declarations: [
    GamesListTableComponent,
    DevelopersListTableComponent,
    PublishersListTableComponent,
    FavouritesListTableComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [
    GamesListTableComponent,
    DevelopersListTableComponent,
    PublishersListTableComponent,
    FavouritesListTableComponent
  ]
})
export class TablesModule { }
