function printRange(start, stop, skip){
    var startCount = start;
    if (!stop && !skip){
        var startCount = 0;
        var stop = start;
    }
    if(!skip){
        var add = 1;
    }
    for(var i = startCount; i < stop; i += skip){
        console.log(i);
    }
}

printRange(-10,-2,2);