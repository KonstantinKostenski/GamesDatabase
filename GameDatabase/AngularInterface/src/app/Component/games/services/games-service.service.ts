import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GamesListItem } from '../../Tables/games-list/games-list-datasource';

@Injectable({
  providedIn: 'root'
})
export class GamesServiceService {

  constructor(private httpService: HttpClient) { }

  getAllGames(): Observable<GamesListItem[]>{
    return this.httpService.get<GamesListItem[]>("api/Games");
  }
}
