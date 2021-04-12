import { GamesListComponent } from './Component/games/games-list/games-list.component';
import { DeveloperListComponent } from './Component/developers/developer-list/developer-list.component';
import { PublishersListComponent } from './Component/publishers/publishers-list/publishers-list.component';
import { RegisterComponent } from './Component/users/register/register.component';
import { LogInComponent } from './Component/users/log-in/log-in.component';
import { LandingPageComponent } from './Component/landing-page/landing-page.component';
import { FavouritesListComponent } from './Component/games/favourites-list/favourites-list.component';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';

const routes: Routes = [
  { path: '', component: LandingPageComponent, pathMatch: 'full' },
  { path: "Games", component: GamesListComponent },
  { path: "Developers", component: DeveloperListComponent },
  { path: "Publishers", component: PublishersListComponent },
  { path: "Register", component: RegisterComponent },
  { path: "Login", component: LogInComponent },
  { path: "Favourites", component: FavouritesListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
