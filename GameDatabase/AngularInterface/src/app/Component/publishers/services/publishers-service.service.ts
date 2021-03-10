import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Publisher, PublisherSearch } from '../../../Models/Publisher';

@Injectable({
  providedIn: 'root'
})
export class PublishersServiceService {

  constructor(private httpClient: HttpClient) { }

  getGamesByPageNumber(pageNumber: number) {

    //this.httpClient.get();
  }

  search(searchObject: PublisherSearch) {
    return this.httpClient.post<Publisher[]>("api/Publishers/Search", searchObject);
  }
}
