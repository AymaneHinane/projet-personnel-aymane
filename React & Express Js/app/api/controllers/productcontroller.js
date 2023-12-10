

const product = require("../models/Product");
const productService = require("../Services/ProductService");
const ProductLibrary = require("../models/ProductLibrary")
const Reservation  = require("../models/Reservation")


const addCategory = async (req, res) => {
    console.log('here');
    try {
        const result = await productService.createCategory(req.body);
        res.status(200).json(result);
    } catch (err) {
        res.status(500).json(error);
    }
}

const getCategory = async (req, res) => {
    try {
        const result = await productService.getAllCategory();
        res.status(200).json(result);
    } catch (err) {
        res.status(500).json(error);
    }
}

const AddProduct = async (req, res) => {

  console.log(req.body);
    //var NewProduct = new product(req.body);

    product.create(req.body)
        .then(result => {
            console.log("AddProduct");
            console.log(24);
            return res.status(200).json(result)
        })
        .catch(error => {
            return res.status(500).json(error)
        })
};

const getAllProducts = async (req, res) => {

    console.log('get all books');

    await product.find().populate('category')
        .then(result => res.status(200).json(result))
        .catch(error => res.status(500).json(error))

};

const getProductById = async (req, res) => {

    console.log("getProductById");
    console.log(21);
    const idP = req.params.id;

    await product.findById(idP).populate('images')
        .then(result => {
            console.log("getProductById");
            console.log(22);
            res.status(200).json(result)
        })
        .catch(error => {
            res.status(500).json(error)
        });
};

const deleteProductById =async (req, res) => {
    console.log('here 1');
    const idP = req.params.id;

    
    const  exist1 =  await ProductLibrary.findOne({product:idP});

    console.log(exist1);

    if(exist1 ) 
      {
        console.log("exist 1");
         return res.status(405).json({err:'ce produit est disponible dans une librairie'});
      }


    const exist2 = await Reservation.findOne({product:idP,took:true});

    if(exist2)
    {
        console.log("exist 2")
       return  res.status(405).json({err:'ce produit a deja etait prit'});
    }
    

    product.findByIdAndDelete(idP)
        .then(result => {
            
            ProductLibrary.findOneAndDelete({product:idP})
            .then(result=>{}).catch(err=>{})

            res.status(200).json(result)
        
        })
        .catch(error => res.status(500).json(error));

};

const deleteImageById = (req, res) => {
    console.log('here 2');
    const idProduct = req.query.idProduct;
    const idImage = req.query.idImage;
    product.findByIdAndUpdate(
        { _id: idProduct },
        { $pull: { images: idImage } }
    )
        .then(result => res.status(200).json(result))
        .catch(error => res.status(500).json(error));
}

const updateProductById = (req, res) => {
    // const idP=req.params.id;   
    product.findByIdAndUpdate(req.params.id, req.body)
        .then(result => res.status(200).json(result))
        .catch(error => res.status(500).json(error));
};

const AddProductCategory = (req, res) => {
    //$push:{
    product.findByIdAndUpdate({ _id: req.params.idP }, { category: req.body.idC })
        .then(result => res.status(200).json(result))
        .catch(error => res.status(500).json(error));
}


const GetProductByFiltre = async (req, res) => {

    console.log('GetProductByFiltre');
    try {
        const name = req.query.name;
        const category = req.query.category;

        const data = await product.find({ name: new RegExp(name, 'i') })
            .find()
            .populate('category')
            .exec((err, products) => {
               if(err){
                 res.status(402).json(err)
               }else if(category.length > 0){
                   
                    var data = products.filter(product => product.category.name === category)
                    res.status(200).json(data)
                }else{
                    res.status(200).json(products)
                }
            });

    } catch (err) {
        res.status(500).json(err);
    }

}


module.exports = {
    AddProduct,
    getAllProducts,
    getProductById,
    deleteProductById,
    updateProductById,
    addCategory,
    getCategory,
    AddProductCategory,
    deleteImageById,
    GetProductByFiltre

}