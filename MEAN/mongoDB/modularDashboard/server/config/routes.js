//Require Mongoose for Database Connection
var mongoose = require('mongoose');

//Getting Model information and controller information
var Mongoose = mongoose.model('Mongoose'); 
var mongooses = require('../controllers/animal.js')

module.exports = function(app) {

    // GET ROUTES
    app.get('/', function(req, res) {
        mongooses.showAll(req, res);
    })
    app.get('/mongooses/new', function(req, res) {
        res.render('new');
    })
    app.get('/mongooses/:id', function(req, res) {
        mongooses.showOne(req, res, 'show');
    })
    app.get('/mongooses/delete/:id', function(req, res) {
        mongooses.delete(req, res)
    })
    app.get('/mongooses/edit/:id', function(req, res) {
        mongooses.showOne(req, res, 'update');
    })

    //POST ROUTES
    app.post('/mongooses/edit/:id', function(req, res) {
        mongooses.update(req, res)
    })
    app.post('/mongooses', function(req, res) {
        mongooses.new(req, res)
    })

}