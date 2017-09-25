function slots(quarters, pass){
    while(quarters > 0){
        quarters -- 
        var win = 10;
        var rand = Math.trunc(Math.random() * 100);
       if ( quarters > pass) {
            return quarters;
            break;
        } else if ( win == rand) {
            var amount = Math.trunc(Math.random() * 50) + 50;
            quarters = quarters + amount;
        } else if ( quarters == 0 ) {
            return 0;
        }
    }
}
var quarters = 10;
var pass = 200;

console.log(slots(quarters, pass))