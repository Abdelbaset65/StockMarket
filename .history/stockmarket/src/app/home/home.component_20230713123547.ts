import { Component } from '@angular/core';
import { Router } from '@angular/router';
import 

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  newUserName: string = '';
  newPassword: string = '';
  newEmail: string = '';

  constructor() { }

}
