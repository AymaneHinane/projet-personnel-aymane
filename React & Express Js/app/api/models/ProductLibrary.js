var mongoose = require('mongoose');


const ProductLibrarySchema =  mongoose.Schema({
    quantite:Number,
    library:{
        type: mongoose.Types.ObjectId,
        ref:"Library"
    },
    product:{
        type: mongoose.Types.ObjectId,
        ref:"Product"
    },
    quantite:Number
})

const ProductLibrary = mongoose.model('ProductLibrary',ProductLibrarySchema);

module.exports = ProductLibrary;