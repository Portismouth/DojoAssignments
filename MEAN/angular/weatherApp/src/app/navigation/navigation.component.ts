import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {

  constructor( private _dataservice: DataService ) { }

  navigation: string[] = [];

  getWeather(data){
    console.log('Navigation sending:', data)
    this._dataservice.getData(data);
  }

  ngOnInit() {
    this.navigation = this._dataservice.getNav();
  }

}
