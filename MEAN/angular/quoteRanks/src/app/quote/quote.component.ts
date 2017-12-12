import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-quote',
  templateUrl: './quote.component.html',
  styleUrls: ['./quote.component.css']
})
export class QuoteComponent implements OnInit {
  @Input() myQuotes
  @Input() index

  @Output() vote = new EventEmitter();
  constructor() { }

  voteTrigger(data, action){
    let obj = {
      index: data,
      action: action
    }
    this.vote.emit(obj)
  }
  ngOnInit() {
  }

}
