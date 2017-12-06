import { Component } from '@angular/core';
import * as moment from 'moment';
import * as momentTimeZone from 'moment-timezone'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Time Zone';
  date = new Date();
  switch = false;
  last;

  newDate(timezone) {
    console.log("clicked")
    if(timezone == 'clear'){
      this.date = new Date();
      return;
    }
    this.date = momentTimeZone().tz(timezone).format('YYYY-MM-DD HH:mm')
    this.last = timezone;
    return;
  }
}
