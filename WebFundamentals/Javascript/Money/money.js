function thirty(days){
    var money = 0;
    for(var i = 1; i <= days; i++){
        if(i == 1){
            money = 0.01;
            console.log(i);
            console.log(money);
        } else {
            money = money * 2;
            console.log(i);
            console.log(money);
        }
    }
    console.log(money)
}
var days = 30;
thirty(days);