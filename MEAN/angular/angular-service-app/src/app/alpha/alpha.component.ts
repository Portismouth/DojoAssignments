import { Component, OnInit } from '@angular/core';


import { DataService } from '../data.service';

@Component({
  selector: 'app-alpha',
  templateUrl: './alpha.component.html',
  styleUrls: ['./alpha.component.css']
})
export class AlphaComponent implements OnInit {

  numbers: number[] = [];

  constructor( private _dataService: DataService ) { }

  
  ngOnInit() {
    this.numbers = this._dataService.retreiveNumbers('alpha');
  }

  pushOne() {
    let rand = Math.floor(Math.random() * 10) + 1
    this._dataService.addNumber(rand, 'alpha');
  }

}
