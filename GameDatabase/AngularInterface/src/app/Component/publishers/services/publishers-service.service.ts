import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PublishersServiceService {

  constructor(private httpClient: HttpClient) { }

  getGamesByPageNumber(pageNumber: number) {

    //this.httpClient.get();
  }
}
