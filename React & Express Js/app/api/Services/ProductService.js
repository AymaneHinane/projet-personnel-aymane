const productModel=require("../models/Product")
const categoryModel = require("../models/Category");




const getAllCategory = async ()=>{
    return await categoryModel.find();
}


const createCategory = async (category)=>{
    console.log('here');
      return await categoryModel.create(category);
}




const AddProduct =async(product)=>{

    try{
      var NewProduct = await new productModel(product);
      NewProduct.save();
      return NewProduct;
    }catch(err)
    {
        throw err;
    }

}

 const GetAllProducts = async ()=>{
     console.log("hello");
    try{
      var result  =  productModel.find();
      console.log(result);
      return result;
    }catch(err)
    {
        throw err;
    }
    
}



// const GetProductById =

// const updateProductById = 

// const DeleteProduct = 


module.exports={
    AddProduct,
    GetAllProducts,
    getAllCategory,
    createCategory
}