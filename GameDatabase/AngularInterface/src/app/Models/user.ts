export class RegisterUserModel {
  password: string;
  repeatPassword: string;
  firstName: string;
  lastName: string;
  username: string;
}

export class LoginUserModel {
  username: string;
  password: string;
}

export class User {
  password: string;
  firstName: string;
  lastName: string;
  username: string;
  token: string;
}
