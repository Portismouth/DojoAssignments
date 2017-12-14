var mongoose = require('mongoose');

var NotesSchema = new mongoose.Schema({
    text: {
        type: String,
        required: true,
        minlength: 3,
        trim: true
    }
},{ timestamps: true });

mongoose.model('Note', NotesSchema);
var Note = mongoose.model('Note')