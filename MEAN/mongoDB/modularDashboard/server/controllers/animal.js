//Database connection
var mongoose = require("mongoose");

//pulling in the model
var Mongoose = mongoose.model('Mongoose')

module.exports = {

    showAll: function(req, res) {
        Mongoose.find({}, function(err, mongooses) {
            res.render('index', {context: mongooses});
        })
    },

    showOne: function(req, res, page) {
        Mongoose.findOne({_id: req.params.id}, function(err, mongoose) {
            res.render(page, {context: mongoose});
        })
    },

    delete: function(req, res) {
        Mongoose.remove({_id: req.params.id}, function(err) {
            if(err) {
                console.log('something went wrong')
            } else {
                console.log("Mongoose deleted")
                res.redirect("/")
            }
        })
    },

    update: function(req, res) {
        Mongoose.update({_id: req.params.id}, {name: req.body.Name}, function(err, mongoose) {
            res.redirect("/mongooses/edit/"+req.params.id)
        })
    },

    new: function(req, res) {
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
    }

}