var my_module = require('./mathlib')();

var x = my_module.add(1,2);
var y = my_module.multiply(1,2);
var z = my_module.square(2);

console.log(x, y, z)