function checkMoney(days){
    var money = 0;
    for(var i = 1; i <= days; i++){
        if(i == 1){
            money = 0.01;
        } else {
            money = money * 2;
        }
    }
    console.log(money)
}


function checkDays(total){
    var checkdays = 1;
    var checkMoney = 0.01;
    while(checkMoney <= total){
        checkMoney = checkMoney + checkMoney;
        checkdays ++;
    }
    console.log(checkdays)
}

var days = 30;
var total= Infinity;
checkMoney(days);
checkDays(total);