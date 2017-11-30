// require express
var express = require("express");
var session = require('express-session');
var bodyParser = require('body-parser');



// path module -- try to figure out where and why we use this
var path = require("path");

// create the express app
var app = express();
app.use(session({secret: 'codingdojorocks'}));  // string for encryption

// use it!
app.use(bodyParser.urlencoded({ extended: true }));

// static content
app.use(express.static(path.join(__dirname, "./static")));

// setting up ejs and our views folder
app.set('views', path.join(__dirname, './views'));
app.set('view engine', 'ejs');

// root route to render the index.ejs view
app.get('/', function(req, res) {
    res.render("index");
});

app.get('/show', function(req, res) {
    res.render("show", {'info': req.session.user});
});

app.post('/user', function(req, res) {
    console.log("POST DATA", req.body);
    req.session.user = {
        'name': req.body.Name,
        'language': req.body.Language,
        'location': req.body.Location,
        'comment': req.body.Comment
    }
    res.redirect('/show');
});

// tell the express app to listen on port 8000
app.listen(8000, function() {
 console.log("listening on port 8000");
});