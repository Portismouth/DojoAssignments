// Requires
var express = require('express');
var bodyParser = require('body-parser');
var mongoose = require('mongoose');
var app = express();
var path = require('path');


app.use(bodyParser.urlencoded({ extended: true }));
app.use(express.static(path.join(__dirname, './static')));

app.set('views', path.join(__dirname, './views'));
app.set('view engine', 'ejs');

//Connect to DB
mongoose.connect('mongodb://localhost/basicApp');
//Make mongoose use global promise library
mongoose.Promise = global.Promise;

//Test user model
var UserSchema = new mongoose.Schema({
    name: String,
    age: Number
   })
var User = mongoose.model('User', UserSchema); 

//Quote Model
var quoteSchema = new mongoose.Schema({
    name: String,
    quote: String
   })
var Quote = mongoose.model('Quote', quoteSchema); 


// Routes
app.get('/', function(req, res) {
    res.render('index');
})

app.get('/quotes', function(req, res) {
    Quote.find({}, function(err, quotes) {
        console.log(quotes)
        res.render('quotes', {context: quotes});
    })
})

app.post('/quotes', function(req, res) {
    var quote = new Quote({
        name: req.body.Name,
        quote: req.body.Quote
    })
    quote.save(function(err) {
        if(err) {
          console.log('something went wrong');
        } else {
          console.log('successfully added a quote!');
          res.redirect('/quotes');
        }
      })
})


// Setting our Server to Listen on Port: 8000
app.listen(8000, function() {
    console.log("listening on port 8000");
})
