import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'Rxjs';
import { HttpClient } from '@angular/common/http';
import {Headers, Http, Response} from '@angular/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class DataService {

  constructor( private _http: Http ) { }

  retrieveData(user) {
    let something = this._http.get(`https://api.github.com/users/`+user)
      .map(res => res.json())
      .toPromise();
    return something
  }

}
