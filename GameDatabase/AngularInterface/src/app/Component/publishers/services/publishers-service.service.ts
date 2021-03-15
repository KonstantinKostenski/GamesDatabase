import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Publisher, PublisherSearch } from '../../../Models/Publisher';

@Injectable({
  providedIn: 'root'
})
export class PublishersServiceService {

  constructor(private httpClient: HttpClient) { }

  getAll(pageNumber: number, pageSize: number) {
    return this.httpClient.get<Publisher[]>("api/Publishers?pageNumber=" + pageNumber + "&pageSize=" + pageSize);
  }

  search(searchObject: PublisherSearch) {
    return this.httpClient.post<Publisher[]>("api/Publishers/Search", searchObject);
  }

  add(publisher: Publisher) {
    return this.httpClient.post<Publisher>("api/Publishers", publisher);
  }

  update(publisher: Publisher) {
    return this.httpClient.put<any>("api/Publishers/" + publisher.id, publisher);
  }
}
