function starString(x){
    let stars = ""
    if(x == 0){return stars}
    for(let i = 1; i<=x ; i++){
        stars+= "*"
    }
    return stars
}
// console.log(starString(5))

function drawStars(arr){
    for(let x = 0; x <= arr.length; x++){
        let stars = ""
        if(typeof arr[x] === 'string')
        {
            var word = arr[x]
            for(let i = 0; i<= word.length; i++){
                stars += word.charAt(0);
            }
            console.log(stars)
        }
        if(typeof arr[x] === 'number'){
            if(arr[x] == 0){console.log(stars)}
            for(let i = 1; i<=arr[x] ; i++){
                stars+= "*"
            }
            console.log(stars)
        }
    }
}
drawStars([3,"hello",9]);