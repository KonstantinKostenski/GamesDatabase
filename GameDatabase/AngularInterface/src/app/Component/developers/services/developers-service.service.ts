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
}
