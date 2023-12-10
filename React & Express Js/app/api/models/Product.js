var mongoose = require('mongoose');



const productSchema =  mongoose.Schema({
    name:String,
    description:String,
    //price:Number,
   // quantite:Number,
    category:{
        type: mongoose.Types.ObjectId,
        ref:"Category"
    },
    images:[{
        type: mongoose.Types.ObjectId,
        ref:"Image"
    }]
})

const Product = mongoose.model('Product',productSchema);

module.exports = Product;