import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Switchboard';
  switches = [
    {
      text: 'Off',
      bool: false,
    },
    {
      text: 'Off',
      bool: false,
    },
    {
      text: 'Off',
      bool: false,
    },
    {
      text: 'Off',
      bool: false,
    },
    {
      text: 'Off',
      bool: false,
    },
    {
      text: 'Off',
      bool: false,
    },
    {
      text: 'Off',
      bool: false,
    },
    {
      text: 'Off',
      bool: false,
    },
    {
      text: 'Off',
      bool: false,
    },
    {
      text: 'Off',
      bool: false,
    },
    {
      text: 'Off',
      bool: false,
    },
    {
      text: 'Off',
      bool: false,
    },
  ]

  toggle(idx){
    let current = this.switches[idx]
    if(current.bool == false){
      current.bool = true
      current.text = 'On'
    } else {
      current.bool = false
      current.text = 'Off'
    }
    return;
  }
}
