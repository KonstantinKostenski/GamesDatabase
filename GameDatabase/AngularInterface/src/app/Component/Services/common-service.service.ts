import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormControl } from '@angular/forms';
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

  getErrorMessage(control: FormControl) {
    console.log(control);
    if (control.hasError('required')) {
      return "You must enter a value";
    }

    if (control.hasError('minlength')) {
      return `Required length is at least ${control.errors.minlength.requiredLength} characters`;
    }

    if (control.hasError('maxlength')) {
      return `Required length is at most ${control.errors.maxlength.requiredLength} characters`;
    }
  }
}