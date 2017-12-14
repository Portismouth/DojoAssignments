var NotesController = require('../controllers/notes')
var mongoose = require('mongoose');
var Note = mongoose.model('Note');

module.exports = function(app){
    app.get('/notes', NotesController.getAll);
    app.post('/notes', NotesController.create);
    app.all("*", (request, response) => { response.sendFile(path.resolve("./public/dist/index.html")) });
}