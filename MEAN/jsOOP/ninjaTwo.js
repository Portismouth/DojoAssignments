function Ninja(name){
    this.name = name;
    this.health =  100;
    let speed = 3;
    let strength = 3;

    this.sayName = function(){
        console.log("My ninja name is:", this.name)
        return this
    }
    this.ShowStats = function(){
        console.log("Health:", this.health,"Speed:", speed,"Strength:", strength)
        return this
    }
    this.drinkSake = function(){
        this.health += 10
        return this
    }
    this.punch = function(obj){
        obj.health -= 5
        return this
    }
}

const mitchell = new Ninja("Mitchell");
const redNinja = new Ninja("Red Ninja");
mitchell.punch(redNinja).punch(redNinja).punch(redNinja);
redNinja.ShowStats();
mitchell.ShowStats();