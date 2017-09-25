function printArray(arr, symbol){
    if(reversed){
        newArr = [];
        for(var i = arr.length-1; i >= 0; i--){
            newArr.push(arr[i]);
        }
        arr = newArr;
    }
    for(var i in arr){
        console.log(''+ i, symbol, arr[i]);
    }
}

var arr = ['James', 'Jill', 'Jane', 'Jack']
var symbol = '+';
var reversed = false;
printArray(arr, symbol, reversed);