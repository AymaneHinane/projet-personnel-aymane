var mongoose = require('mongoose');
 
var LibrarySchema = new mongoose.Schema({
    name: String,
   
});
 
//Image is a model which has a schema imageSchema
 
module.exports = new mongoose.model('Library', LibrarySchema);