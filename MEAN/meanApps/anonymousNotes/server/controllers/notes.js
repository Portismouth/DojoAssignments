var mongoose = require('mongoose');
var Note = mongoose.model('Note');

module.exports = {
    create: function(req, res){
        console.log("===== Hit Post Route =====")
        Note.create(req.body).then( note => res.json(note) ).catch( error => console.log(error) )
    },
    getAll: function(req, res){
        Note.find({}).sort('-createdAt').then( allNotes => res.json(allNotes) ).catch( error => console.log(error) )
    }
}