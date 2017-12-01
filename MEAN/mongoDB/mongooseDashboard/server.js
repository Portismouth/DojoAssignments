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
mongoose.connect('mongodb://localhost/mongooseDashboard');
//Make mongoose use global promise library
mongoose.Promise = global.Promise;

//Test user model
var MongooseSchema = new mongoose.Schema({
    name: String,
   })
var Mongoose = mongoose.model('Mongoose', MongooseSchema); 



// Routes
app.get('/', function(req, res) {
    Mongoose.find({}, function(err, mongooses) {
        res.render('index', {context: mongooses});
    })
})
app.get('/mongooses/new', function(req, res) {
    res.render('new');
})
app.get('/mongooses/:id', function(req, res) {
    Mongoose.findOne({_id: req.params.id}, function(err, mongoose) {
        res.render('show', {context: mongoose});
    })
})
app.get('/mongooses/delete/:id', function(req, res) {
    Mongoose.remove({_id: req.params.id}, function(err) {
        if(err) {
            console.log('something went wrong')
        } else {
            console.log("Mongoose deleted")
            res.redirect("/")
        }
    })
})
app.get('/mongooses/edit/:id', function(req, res) {
    Mongoose.findOne({_id: req.params.id}, function(err, mongoose) {
        res.render('update', {context: mongoose});
    })
})

app.post('/mongooses/edit/:id', function(req, res) {
    Mongoose.update({_id: req.params.id}, {name: req.body.Name}, function(err, mongoose) {
        res.redirect("/mongooses/edit/"+req.params.id)
    })
})
app.post('/mongooses', function(req, res) {
    var mongoose = new Mongoose({
        name: req.body.Name,
    })
    mongoose.save(function(err) {
        if(err) {
          console.log('something went wrong');
        } else {
          console.log('successfully added a mongoose!');
          res.redirect('/');
        }
      })
})


// Setting our Server to Listen on Port: 8000
app.listen(8000, function() {
    console.log("listening on port 8000");
})
