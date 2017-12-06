import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Random Barcode';
  
  bgColors = ['Aqua', 'BlueViolet', 'BurlyWood', 'Chartreuse', 'CornflowerBlue', 'DarkCyan', 'DarkMagenta', 'DeepPink', 'DodgerBlue', 'GoldenRod', 'LavenderBlush', 'LightSkyBlue'];
  random = this.bgColors.sort(function(a,b){return 0.5 - Math.random()});

  randomNumber(){
    return Math.floor(Math.random() * this.bgColors.length) + 1;
  };
}
