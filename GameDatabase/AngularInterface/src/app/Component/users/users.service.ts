import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginUserModel, RegisterUserModel, User } from '../../Models/User';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor(private httpService: HttpClient) { }

  register(registerModel: RegisterUserModel) {
    return this.httpService.post<RegisterUserModel>("api/Users/Register", registerModel);
  }

  authenticate(loginModel: LoginUserModel) {
    return this.httpService.post<User>("api/Users/Authenticate", loginModel);
  }

  //authorize(registerModel: RegisterUserModel) {
  //  return this.httpService.post<RegisterUserModel>("api/Users", registerModel);
  //}
}
