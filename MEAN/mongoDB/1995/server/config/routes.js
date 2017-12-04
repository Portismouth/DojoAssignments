//Require Mongoose for Database Connection
var mongoose = require('mongoose');

//Getting Model information and controller information
var userController = require('../controllers/user.js')

module.exports = function(app) {

    // GET ROUTES
    app.get('/', function(req, res) {
        userController.showAll(req, res);
    })
    app.get('/new/:name', function(req, res) {
        userController.new(req, res);
    })
    app.get('/remove/:name', function(req, res) {
        userController.delete(req, res);
    })
    app.get('/:name', function(req, res) {
        userController.showOne(req, res);
    })

}