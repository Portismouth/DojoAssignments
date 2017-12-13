import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';

@Component({
  selector: 'app-city',
  templateUrl: './city.component.html',
  styleUrls: ['./city.component.css']
})
export class CityComponent implements OnInit {
  data: any[] = [];

  constructor( private _dataservice: DataService ) { }

  ngOnInit() {
    this._dataservice.data.subscribe(
      (data) => {this.data = data}
    );
  }

}
