function slots(quarters, pass){
    while(quarters > 0){
        quarters -- 
        var win = 10;
        var rand = Math.floor((Math.random() * 100) + 1); // Creates random number so see if winner
       if ( quarters > pass) {
            // Checks if you have won enough quarts to quit
            return quarters;
            break;
        } else if ( win == rand) {
            // If you won add the random number from 50 - 100 of quarters you won to your current amount
            var amount = Math.trunc(Math.random() * 50) + 50;
            quarters = quarters + amount;
        } else if ( quarters == 0 ) {
            // All out of Quarters :(
            return 0;
        }
    }
}
var quarters = 10; // Amount of Starting Quarters
var pass = 50; // If you Make this much, Stop playing

console.log(slots(quarters, pass))