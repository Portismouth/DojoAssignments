// Math One
// function zero_negativity(arr){
//     let flag = true;
//     for(let i = 0; i < arr.length; i++){
//         if(arr[i] < 0){
//             flag = false
//         }
//     }
//     return flag;
// }
// if(zero_negativity([1,2,-3])){
//     console.log("No Negatives")
// }

//Math Two
function is_even(int){
    if(int % 2 === 0){
        return true
    } else {
        return false
    }
}

//Math three
function how_many_even(arr){
    let count = 0;
    for(let i = 0; i < arr.length; i++){
        if(arr[i] % 2 === 0){
            count++;
        }
    } 
    return count;
}

//Math Four
function create_dummy_array(n){
    let arr = []
    for(let i = 1; i<= n; i++){
        let x = Math.floor((Math.random() * 10) + 1)
        arr.push(x);
    }
    return arr
}

//Math Five
function random_choice(arr){
    let max = arr.length ;
    let rand = Math.floor((Math.random() * max))
    return arr[rand]
}
