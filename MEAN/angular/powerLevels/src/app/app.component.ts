import { Component } from '@angular/core';
import { FormControl } from '@angular/forms/src/model';
import { variable } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Power Levels';
  power: number = 0;
  
  powerForm = 0;

  onSubmit(data){
    console.log("submitted:", data)
    this.power = data;
  }
}
