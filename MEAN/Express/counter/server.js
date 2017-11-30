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
    if (!req.session.count) {
        req.session.count = 1;
    } else {
        req.session.count++;
    }
    var context = {
        'count' : req.session.count,
    }

 res.render("index", context);
})

app.get('/double', function(req, res) {
//  console.log("POST DATA", req.body);
    req.session.count++;
 res.redirect('/');
});
app.get('/reset', function(req, res) {
    //  console.log("POST DATA", req.body);
    req.session.count = null;
  res.redirect('/');
})

// tell the express app to listen on port 8000
app.listen(8000, function() {
 console.log("listening on port 8000");
});