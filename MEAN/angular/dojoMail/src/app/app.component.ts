import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Dojo Mail';
  emails = [
  {
    email: 'mitchell@gmail.com',
    importance: true,
    subject: 'Stuff',
    content: 'Lorem ipsum dolor sit amet'
  },
  {
    email: 'someone@gmail.com',
    importance: false,
    subject: 'Other Stuff',
    content: 'Lorem ipsum dolor sit amet'
  },
  {
    email: 'stephen@gmail.com',
    importance: true,
    subject: 'I am sick',
    content: 'Lorem ipsum dolor sit amet'
  },
  {
    email: 'user@gmail.com',
    importance: true,
    subject: 'User Stuff',
    content: 'Lorem ipsum dolor sit amet'
  }];
}
