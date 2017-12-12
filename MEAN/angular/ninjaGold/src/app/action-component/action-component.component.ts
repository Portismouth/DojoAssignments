import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';
import { DataService } from '../data.service';

@Component({
  selector: 'app-action-component',
  templateUrl: './action-component.component.html',
  styleUrls: ['./action-component.component.css']
})
export class ActionComponentComponent implements OnInit {

  constructor( private _dataService: DataService ) { }
  @Input() index; 
  @Input() action; 
  @Output() workEmitter = new EventEmitter();
  
  findGold(action: number){
    console.log('Action:', action)
    this._dataService.updateGold(action);
    this.workEmitter.emit();
  }

  ngOnInit() {
  }
}
