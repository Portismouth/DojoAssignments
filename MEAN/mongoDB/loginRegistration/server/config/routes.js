//Require Mongoose for Database Connection
var mongoose = require('mongoose');

//Getting Model information and controller information
var userController = require('../controllers/user.js')

module.exports = function(app) {

    // GET ROUTES
    app.get('/', function(req, res) {
        userController.load(req, res, 'index')
    })
    app.get('/logout', function(req, res) {
        userController.logout(req, res)
    })

    //POST ROUTES
    app.post('/register', function(req, res) {
        userController.register(req, res);
    });
    app.post('/login', function(req, res) {
        userController.login(req, res);
    });

}