var HOUR = 11;
var MINUTE = 20;
var PERIOD = "PM";

function checkTime(){
    if(PERIOD == "AM"){
        if(MINUTE < 30){
            console.log('It is just after', HOUR, 'in the morning');
        } else if (MINUTE > 30 && MINUTE <= 60) {
            console.log('It is almost', HOUR + 1, 'in the morning');
        } else {
            console.log('That is not a valid time');
        }
    } else {
        if(MINUTE < 30){
            console.log('It is just after', HOUR, 'in the afternoon');
        } else if (MINUTE > 30 && MINUTE <= 60) {
            console.log('It is almost', HOUR + 1, 'in the afternoon');
        } else {
            console.log('That is not a valid time');
        }
    }
}

checkTime();