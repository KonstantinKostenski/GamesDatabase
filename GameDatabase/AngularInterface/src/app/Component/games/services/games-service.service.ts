import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Game } from '../../../Models/Game';
import { GamesListItem } from '../../Tables/games-list/games-list-datasource';

@Injectable({
  providedIn: 'root'
})
export class GamesServiceService {

  constructor(private httpService: HttpClient) { }

  getAllGames(pageNumber: number, pageSize: number): Observable<Game[]>{
    return this.httpService.get<Game[]>("api/Games?pageNumber=" + pageNumber + "&pageSize=" + pageSize);
  }

  saveNewGame(game: Game) {
    return this.httpService.post<Game>("api/Games", game);
  }

  delete(id: number) {
    return this.httpService.delete<any>("api/Games/" + id);
  }

  update(game: Game, id: number) {
    return this.httpService.put<any>("api/Games/" + id, game);
  }

  search(game: Game) {
    return this.httpService.post<Game>("api/Games/Search", game);
  }

  facouriteValidityPeriod(gameId: number) {
    return this.httpService.get<any>("api/Games/Favourite?gameId="+ gameId);
  }
}
