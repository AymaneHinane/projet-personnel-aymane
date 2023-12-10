const mongoose = require("mongoose");

const CategoryShema  = new mongoose.Schema({
    name:String    
});

const Category = mongoose.model("Category",CategoryShema);

module.exports = Category;