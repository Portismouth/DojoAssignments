import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { FormComponent } from './form/form.component';
import { ScoreComponent } from './score/score.component';

import { FormsModule } from '@angular/forms'; // <-- Import FormsModule
import { HttpModule } from '@angular/http'; // <-- Import HttpModule

import { DataService } from './data.service';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    FormComponent,
    ScoreComponent
  ],
  imports: [
    BrowserModule,
    FormsModule, // <-- Include module in our AppModules
    HttpModule, // <-- Include module in our AppModules
    HttpClientModule
  ],
  providers: [DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
