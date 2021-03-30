import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material';
import { Router } from '@angular/router';
import { ErrorPopUpComponent } from '../PopUps/error-pop-up/error-pop-up.component';

@Injectable({
  providedIn: 'root'
})
export class CommonServiceService {

  constructor(private http: HttpClient, public dialog: MatDialog, private router: Router) { }

  getGenres() {
    return this.http.get<any>("api/Common/GetGenres");
  }

  handleError(errors: any[], statusCode: number) {
    debugger;
    if (statusCode === 401) {
      this.router.navigateByUrl("Login");
    }
    else {
      const dialogRef = this.dialog.open(ErrorPopUpComponent, {
        data: errors
      });
    }
   
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

  parseJwt(token) {
    if (token) {
      const base64Url = token.split('.')[1];
      const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
      const jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
      }).join(''));

      return JSON.parse(jsonPayload);
    }

    return "";
  }

  checkIfTokenHasExpired() {
    debugger;
    let headers = new HttpHeaders().set('Authorization', "Bearer " + localStorage.getItem("token"));
    return this.http.get("api/Users/CheckIfTokenHasExpired", { headers: headers });
  }
}
