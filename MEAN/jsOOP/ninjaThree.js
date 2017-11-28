class Ninja{
    constructor(name){
        this.name = name;
        this.health = 100;
        this.speed = 3;
        this.strength = 3;
    }

    //Ninja Methods
    sayName(){
        console.log(`My name is ${this.name}`);
        return this
    }
    drinkSake(){
        this.health += 10
        return this
    }
    showStats(){
        console.log(`${this.name}'s stats\nHealth: ${this.health} Speed: ${this.speed} Strength: ${this.strength}`)
        return this
    }
}

class Sensei extends Ninja{
    constructor(name){
        super(name)
        this.health = 200;
        this.speed = 10;
        this.strength = 10
    }

    //Sensei Methods
    speakWisdom(){
        super.drinkSake();
        console.log("What one programmer can do in one month, two programmers can do in two months")
    }
}

const mitchell = new Ninja("Mitchell")
mitchell.drinkSake();
mitchell.showStats();

const superMitchell = new Sensei("Super Mitchell")
superMitchell.speakWisdom();
superMitchell.showStats();