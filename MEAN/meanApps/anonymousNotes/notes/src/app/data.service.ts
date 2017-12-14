import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { BehaviorSubject } from 'Rxjs';

@Injectable()
export class DataService {
  notes = new BehaviorSubject([]);

  constructor( private _http: Http ) { }


  retrieveAll() {
    this._http.get('/notes').subscribe(
      n => this.notes.next(n.json()),
      errorResponse => console.log(errorResponse)
    );
  }

  createNote(note) {
    console.log("===== Hit Service =====")
    this._http.post('/notes', note).subscribe(
      response => this.retrieveAll(),
      errorResponse => console.log(errorResponse)
    );
  }

}
