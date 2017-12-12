import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { ActionComponentComponent } from './action-component/action-component.component';
import { ListComponentComponent } from './list-component/list-component.component';

import { DataService } from './data.service';


@NgModule({
  declarations: [
    AppComponent,
    ActionComponentComponent,
    ListComponentComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [ DataService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
