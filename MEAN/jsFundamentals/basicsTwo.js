function magic_multiply(x, y){
    // --- your code here ---
    if(x.constructor === Array){
        for(let i = 0; i < x.length; i++){
            x[i] *= y;
        }
        return x;
    }
    else if(typeof x === "number"){
        if(typeof y === "string"){
            return "Error: cannot multiply by string"
        }
        if(x ==0 && y == 0){
            return "All inputs 0"
        }
        x = x * y;
        return x;
    }
    else if(typeof x === "string" && typeof y === "number"){
        let newString = ""
        for(let i = 0; i < y; i ++){
            newString += x;
        }
        return newString;
    }
    else{
        return "No Valid Input"
    }
}

let test1 = magic_multiply(5,2);
console.log("Test One:", test1);
//Returns 10

let test2 = magic_multiply(0,0);
console.log(test2);

let test3 = magic_multiply([1,2,3],2);
console.log("Test Three:", test3);

let test4 = magic_multiply(7, "three");
console.log(test4);

let test5 = magic_multiply("Brendo", 4);
console.log(test5);