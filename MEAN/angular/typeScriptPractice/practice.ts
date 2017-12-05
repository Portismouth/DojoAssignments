var myNum: number = 5;
var myString: string = "Hello Universe";
var myArr: Array<number> = [1,2,3,4];
var myObj: object = { name:'Bill'};
var anythingVariable: any = "Hey";
anythingVariable = 25; 
var arrayOne: Array<Boolean> = [true, false, true, true]; 
var arrayTwo: Array<any> = [1, 'abc', true, 2];
myObj = { x: 5, y: 10 };
// object constructor
// MyNode = (function () {
//     function MyNode(val) {
//         this.val = 0;
//         this.val = val;
//     }
//     MyNode.prototype.doSomething = function () {
//         this._priv = 10;
//     };
//     return MyNode;
// }());
// myNodeInstance = new MyNode(1);
// console.log(myNodeInstance.val);

class MyNode {
    val: number

    constructor(input: number){
        this.val = input
    }

    doSomething(){
        console.log("Hello")
    }
}
let myNodeInstance = new MyNode(1);
console.log(myNodeInstance.val);
myNodeInstance.doSomething();

function myFunction(): void {
    console.log("Hello World");
}
function sendingErrors(): never {
	throw new Error('Error message');
}

myFunction();
