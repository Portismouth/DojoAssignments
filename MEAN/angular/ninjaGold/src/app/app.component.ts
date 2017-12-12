import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
  constructor( private _dataService: DataService ) { }

  title = 'app';
  gold: number = 0;
  actions: string[] = []

  getGold(event){
    console.log('event received')
    this.gold = this._dataService.getGold();
  }
  ngOnInit() {
    this.gold = this._dataService.getGold();
    this.actions = this._dataService.actions;
  }

}
