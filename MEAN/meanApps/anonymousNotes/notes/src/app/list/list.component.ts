import { Component, OnInit } from '@angular/core';
import { Note } from '../note';
import { DataService } from '../data.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  allNotes = [];

  constructor( private _dataservice: DataService ) { }

  ngOnInit() {
    this._dataservice.notes.subscribe(
      (res) => {this.allNotes = res}
    );
    this._dataservice.retrieveAll();
  }

}
