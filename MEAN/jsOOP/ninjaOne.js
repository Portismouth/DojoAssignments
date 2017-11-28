function Ninja(name){
    this.name = name;
    let health =  100;
    let speed = 3;
    let strength = 3;

    this.sayName = function(){
        console.log("My ninja name is:", this.name)
        return this
    }
    this.ShowStats = function(){
        console.log("Health:", health,"Speed:", speed,"Strength:", strength)
        return this
    }
    this.drinkSake = function(){
        health += 10
        return this
    }
}

const mitchell = new Ninja("Mitchell");
mitchell.sayName();
mitchell.ShowStats();
mitchell.drinkSake();
mitchell.ShowStats();