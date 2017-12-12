import { Injectable } from '@angular/core';

@Injectable()
export class DataService {
  gold: number = 0;
  actions: string [] = ['Farm', 'Cave', 'Casino', 'House']
  list: string [] = [];
  constructor() { }

  getGold(){
    return this.gold;
  }

  getList(){
    return this.list;
  }

  updateGold(action) {
    if(action == 0) { 
      // Farm
      this.list.push("You went to the farm and earned 5 gold")
      this.gold += 5 
    }
    if(action == 1) {
      // Cave
      this.list.push("You went to the Cave and earned 10 gold")
      this.gold += 10
    }
    if(action == 2) {
      // Casino
      this.list.push("You went to the Casino and earned 50 gold")
      this.gold += 50
    }
    if(action == 3) {
      // House
      this.list.push("You went to the House and earned 100 gold")
      this.gold += 100
    }
  }

}
