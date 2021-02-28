import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GamesListComponent } from './Component/games/games-list/games-list.component';
import { DeveloperListComponent } from './Component/developers/developer-list/developer-list.component';
import { PublishersListComponent } from './Component/publishers/publishers-list/publishers-list.component';
import { RegisterComponent } from './Component/users/register/register.component';

const routes: Routes = [
  //{ path: '', component: AppComponent, pathMatch: 'full' },
  { path: "Games", component: GamesListComponent },
  { path: "Developers", component: DeveloperListComponent },
  { path: "Publishers", component: PublishersListComponent },
  { path: "Register", component: RegisterComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
