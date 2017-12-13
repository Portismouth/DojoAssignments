import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { CityComponent } from './city/city.component';
import { DataService } from  './data.service';

import { NavigationComponent } from './navigation/navigation.component';
import { FormsModule } from '@angular/forms'; // <-- Import FormsModule
import { HttpClientModule } from '@angular/common/http'; // <-- Import HttpModule


@NgModule({
  declarations: [
    AppComponent,
    CityComponent,
    NavigationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule, // <-- Include module in our AppModules
    HttpClientModule // <-- Include module in our AppModules
  ],
  providers: [DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
