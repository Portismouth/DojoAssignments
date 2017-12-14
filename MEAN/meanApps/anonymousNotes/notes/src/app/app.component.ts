import { Component } from '@angular/core';
import { DataService } from './data.service';
import { Note } from './note';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  note = new Note();

  constructor( private _dataservice: DataService ) { }

  onSubmit(){
    console.log("===== Hit App Component =====")
    this._dataservice.createNote(this.note);
    this.note = new Note();
  }
}
