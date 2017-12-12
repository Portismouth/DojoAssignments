import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';

@Component({
  selector: 'app-sum',
  templateUrl: './sum.component.html',
  styleUrls: ['./sum.component.css']
})
export class SumComponent implements OnInit {
  sum: number;

  constructor( private _dataService: DataService ) { }

  ngOnInit() {
    
  }

  updateSum() {
    this.sum = this._dataService.getSum();
  }

}
