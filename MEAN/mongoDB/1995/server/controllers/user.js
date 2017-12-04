//Database connection
var mongoose = require("mongoose");

//pulling in the model
var User = mongoose.model('User')

module.exports = {

    showAll: function(req, res) {
        User.find({}, function(err, data) {
            res.json(data);
        })
    },

    showOne: function(req, res) {
        User.findOne({name: req.params.name}, function(err, data) {
            res.json(data);
        })
    },

    delete: function(req, res) {
        User.remove({name: req.params.name}, function(err) {
            if(err) {
                console.log('something went wrong')
            } else {
                console.log("Mongoose deleted")
                res.redirect("/")
            }
        })
    },

    new: function(req, res) {
        var user = new User({
            name: req.params.name,
        })
        user.save(function(err) {
            if(err) {
                console.log('something went wrong');
            } else {
                console.log('successfully added', req.params.name);
                res.redirect('/');
            }
        })
    }

}