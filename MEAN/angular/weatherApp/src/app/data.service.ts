import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'Rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class DataService {
  data: BehaviorSubject<any[]> = new BehaviorSubject([]);
  city = 'chicago';

  constructor( private _http: HttpClient ) {
    this.getData(this.city); 
    console.log('Data:', this.data);
  }

  // Navigation items
  navigation: string[] = ['Seattle', 'San Jose', 'Burbank', 'Dallas', 'Atlanta', 'Chicago']
  getNav(){ return this.navigation }

  getData(city){
    this.city = city;
    this._http.get(`http://api.openweathermap.org/data/2.5/weather?q=${city}&APPID=5ca1523bd8e00500e46f40b8ceeec5b0`).subscribe(
      (res: any[]) => { this.data.next(res) }
    );
  }

}
