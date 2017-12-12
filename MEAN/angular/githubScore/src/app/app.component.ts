import { Component } from '@angular/core';
import { DataService } from './data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  user = '';
  response;
  color;
  message;

  constructor( private _dataService: DataService ) { }

  onSubmit(){
    
    this._dataService.retrieveData(this.user)
    .then(data => this.response = this.calculateScore(data))
    .then(m => this.getMessage())
    .catch(err => console.log(err));
  }

  calculateScore(val){
    let score = val.public_repos + val.followers + val.following;
    return score; 
  }

  getMessage(){
    if(this.response < 20){
      this.message = 'Needs Work!'
      this.color = 'red'
    } else if (this.response < 50 && this.response >= 20) {
      this.message = 'A Decent Start'
      this.color = 'orange'
    } else if (this.response < 100 && this.response >= 50) {
      this.message = 'Doing good'
      this.color = 'black'
    } else if (this.response < 200 && this.response >= 100) {
      this.message = 'Great job!'
      this.color = 'green'
    } else if (this.response >= 200) {
      this.message = 'Github Elite'
      this.color = 'blue'
    }
  }
  
}
