function newArray(arr){
    // if the index is a number save it to a new array
    var newArr = [];
    for( i in arr){
        if (typeof arr[i] === 'number'){
            newArr.push(arr[i]);
        }
    }
    console.log(newArr);
}
function spliceArray(arr){
    // cuts the index out if it is a number
    for( i in arr){
        if (typeof arr[i] === 'number'){
            arr.splice(i, 1);
        }
    }
}

var arr = [1, "apple", -3, "orange", 0.5];
newArray(arr); // This returns the new array
spliceArray(arr);// This edits the current array
console.log(arr);