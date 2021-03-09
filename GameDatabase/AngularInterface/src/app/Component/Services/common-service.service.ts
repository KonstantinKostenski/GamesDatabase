import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material';
import { ErrorPopUpComponent } from '../PopUps/error-pop-up/error-pop-up.component';

@Injectable({
  providedIn: 'root'
})
export class CommonServiceService {

  constructor(private http: HttpClient, public dialog: MatDialog) { }

  getGenres() {
    return this.http.get<any>("api/Common/GetGenres");
  }

  handleError(errors: any[]) {
    debugger;
    const dialogRef = this.dialog.open(ErrorPopUpComponent, {
      data: errors
    });
  }
}
