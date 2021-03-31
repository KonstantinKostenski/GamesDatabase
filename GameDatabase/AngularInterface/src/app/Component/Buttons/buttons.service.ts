import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ButtonsService {

  constructor(private http: HttpClient) { }

  favouriteGame(gameId: number, userId: number, isFavourited: boolean) {
    return this.http.get("api/Common/FavouriteGame?gameId=" + gameId + "&userId=" + userId + "&isFavourited=" + isFavourited);
  }
}
