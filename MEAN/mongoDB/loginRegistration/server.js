// Requires
var express = require('express');
var bodyParser = require('body-parser');
var app = express();
var path = require('path');
var session = require('express-session');
app.use(session({secret: 'codingdojorocks'}));

app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json()); 
app.use(express.static(path.join(__dirname, './static')));

app.set('views', path.join(__dirname, './views'));
app.set('view engine', 'ejs');

//Require mongoose set up file
require('./server/config/mongoose.js');


//Connecting to routes
var routes_setter = require('./server/config/routes.js');
routes_setter(app);

// Setting our Server to Listen on Port: 8000
app.listen(8000, function() {
    console.log("listening on port 8000");
})
