import { Injectable } from '@angular/core';

@Injectable()
export class DataService {
  alphaNumbers: number[] = [];
  betaNumbers: number[] = [];
  difference: number;
  constructor() { }

  retreiveNumbers(component: string): number[] {
    if(component == 'alpha'){ return this.alphaNumbers; }
    if(component == 'beta'){ return this.betaNumbers }
  }

  addNumber(num: number, component: string){
    if(component == 'alpha'){ this.alphaNumbers.push(num) }
    if(component == 'beta'){  this.betaNumbers.push(num) }
  }

  getSum(): number {
    let alphaSum = this.alphaNumbers.reduce((a, b) => a + b, 0)
    let betaSum = this.betaNumbers.reduce((a, b) => a + b, 0)
    this.difference = alphaSum - betaSum;
    return this.difference
  }

}
