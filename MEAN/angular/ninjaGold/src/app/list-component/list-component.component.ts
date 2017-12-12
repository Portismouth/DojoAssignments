import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';

@Component({
  selector: 'app-list-component',
  templateUrl: './list-component.component.html',
  styleUrls: ['./list-component.component.css']
})
export class ListComponentComponent implements OnInit {

  constructor( private _dataService: DataService ) { }
  list: string [] = [] 
  
  ngOnInit() {
    this.list = this._dataService.getList();
  }

}
