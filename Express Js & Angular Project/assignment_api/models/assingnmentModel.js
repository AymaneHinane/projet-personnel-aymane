
var mongoose = require('mongoose');


const assignmentSchema =  mongoose.Schema({
    nom:String,
    description:String,
    date_rendu:Date,
    rendu:Boolean,
})

const Assignment = mongoose.model('Assignment',assignmentSchema);

module.exports = Assignment;