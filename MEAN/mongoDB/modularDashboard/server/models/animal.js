//Require Mongoose for Database Connection
var mongoose = require('mongoose');

//CREATING A SCHEMA FOR ANIMAL TABLE
var MongooseSchema = new mongoose.Schema({
    name: String,
   })
var Mongoose = mongoose.model('Mongoose', MongooseSchema); 