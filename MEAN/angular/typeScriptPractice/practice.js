var myNum = 5;
var myString = "Hello Universe";
var myArr = [1, 2, 3, 4];
var myObj = { name: 'Bill' };
var anythingVariable = "Hey";
anythingVariable = 25;
var arrayOne = [true, false, true, true];
var arrayTwo = [1, 'abc', true, 2];
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
var MyNode = /** @class */ (function () {
    function MyNode(input) {
        this.val = input;
    }
    MyNode.prototype.doSomething = function () {
        console.log("Hello");
    };
    return MyNode;
}());
var myNodeInstance = new MyNode(1);
console.log(myNodeInstance.val);
myNodeInstance.doSomething();
function myFunction() {
    console.log("Hello World");
}
function sendingErrors() {
    throw new Error('Error message');
}
myFunction();
