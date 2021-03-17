import { Component } from '@angular/core';
import { CommonServiceService } from './Component/Services/common-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'AngularInterface';
  isLoggedIn: boolean = false;

  constructor(private commonService: CommonServiceService) {

  }

  getUsername() {
    const data = this.commonService.parseJwt(localStorage.getItem("token"));

    if (data) {
      this.isLoggedIn = true;
      return data.username;
    }

    return "";
  }

  logOut() {
    localStorage.removeItem("token");
    this.isLoggedIn = false;
  }


}
