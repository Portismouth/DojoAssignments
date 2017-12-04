//Require Mongoose for Database Connection
var mongoose = require('mongoose');

//CREATING A SCHEMA FOR ANIMAL TABLE
var UserSchema = new mongoose.Schema({
    name: String,
   })
var Mongoose = mongoose.model('User', UserSchema); 