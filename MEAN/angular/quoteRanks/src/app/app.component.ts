import { Component } from '@angular/core';
import { Quote } from './quote';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  quotes: Array<Quote> = [];
  quote = new Quote();
  quotesArray = this.quotes

  onSubmit(){
    this.quotes.push(this.quote);
    this.quote = new Quote();
  }

  dataFromChild(data){
    let something = this.quotes[data.index];

    //This works to order the quote ranking... no idea why, I think it is because I have to run this sort function everytime a vote is cast
    this.quotes.sort(function(a,b){
      return b.rating - a.rating + 1;
    })

    if(data.action == "up"){
      something.rating++
      console.log(this.quotesArray)
    }
    if(data.action == "down"){
      something.rating--
      console.log(this.quotesArray)
    }
    if(data.action == "delete"){
      this.quotes.splice(data.index, 1);
      console.log(this.quotesArray)
    }
  }

}
