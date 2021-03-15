import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Developer, DeveloperSearch } from '../../../Models/Developer';

@Injectable({
  providedIn: 'root'
})
export class DevelopersServiceService {

  constructor(private httpService: HttpClient) { }

  search(searchObject: DeveloperSearch) {
    return this.httpService.post<Developer[]>("api/Developers/Search", searchObject);
  }

  getAll(pageNumber: number, pageSize: number) {
    return this.httpService.get<Developer[]>("api/Developers?pageNumber=" + pageNumber + "&pageSize=" + pageSize);
  }

  add(developer: any) {
    return this.httpService.post<any>("api/Developers", developer);
  }

  delete(id: number) {
    return this.httpService.delete<any>("api/Developers/" + id);
  }

  update(developer: Developer) {
    return this.httpService.put<any>("api/Developers/" + developer.id, developer);
  }
}
