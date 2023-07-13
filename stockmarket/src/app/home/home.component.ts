import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../user';
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  newUser: User = {} as User;
  newUserName: string = '';
  newPassword: string = '';
  newEmail: string = '';

  user: User = {} as User;
  userName: string = '';
  password: string = '';
  email: string = '';

  constructor(
    private router: Router,
  ) {}

  onSignUpSubmit(form: NgForm) {
    this.newUser.userName = this.newUserName;
    this.newUser.password = this.newPassword;
    this.newUser.email = this.newEmail;
    console.log(this.newUser);
    this.router.navigate(['/stocks']);

  }
  onSignInSubmit(form: NgForm) {
    this.user.userName = this.userName;
    this.user.password = this.password;
    this.user.email = this.email;
    console.log(this.user);
    this.router.navigate(['/stocks']);

  }
}
