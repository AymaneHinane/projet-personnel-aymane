

const ProductLibrary = require('../models/ProductLibrary');
const Library = require('../models/Library');


const AddLibrary = async (req, res) => {
   console.log('library add');
    try {
        const data = await Library.create(req.body)
        res.status(200).json(data);
    } catch (err) {
        res.status(500).json(err)
    }
}

const GetAllLibrary  = async (req,res)=>{

    try{
      const data  = await Library.find();
      res.status(200).json(data);
    }catch(err)
    {
        res.status(500).json(err);
    }
}

const GetProductFromLibrary = async (req,res)=>{
    
    try{
        const idL = req.params.idL;
        const idP = req.params.idP;

        const data  = await ProductLibrary.findOne({library:idL,product:idP})
         
        res.status(200).json(data);

    }catch(err)
    {
        res.status(402).json(err);

    }
}

const GetAllProductFromLibrary = async (req,res)=>{
    try{
        const idL = req.params.idL;

        const data  = await ProductLibrary.find({library:idL}).populate({
            path: 'product',
            populate: [
              {
                path: 'category',
               // select: '-__v -_id',
              },
            ],
          })
         
        res.status(200).json(data);

    }catch(err)
    {
        res.status(402).json(err);

    }
}


const AddProductToLibrary = async (req,res) => {
    try{
       const idL = req.params.id;
       const body = req.body;

      const data =  await ProductLibrary.create({library:idL,...body})
      res.status(200).json(data);
    } catch (err) {
        res.status(500).json(err)
    }
}

const UpdateProductQuantity = async (req,res) => {

    console.log("UpdateProductQuantity ");
    try{
       //const idL = req.params.id;

      const data =  await ProductLibrary.findOneAndUpdate({library:req.params.id,product:req.body.product},{quantite:req.body.quantite})
      res.status(200).json(data);
    } catch (err) {
        res.status(500).json(err)
    }
}


const GetAllBook = async (req,res) =>{

       console.log('get all book');
        const data  = await ProductLibrary.find().populate({
            path: 'product',
            populate: [
              {
                path: 'category',
                //select: '-__v -_id',
              },
              {
                path: 'images',
              }
             ],
          }).populate('library');

          res.status(200).json(data)
  try{  }catch(err){
        res.status(500).json(data)
    }
}

const deleteBook = async (req,res)=>{

   try{
    const book = await ProductLibrary.findOneAndDelete({library:req.params.idL,product:req.params.idP})

    res.status(200).json(book)
   }catch(err)
   {
    res.status(500).json(err);
   }
     


}



module.exports={
    AddLibrary,
    AddProductToLibrary,
    UpdateProductQuantity,
    GetAllLibrary,
    GetProductFromLibrary,
    GetAllProductFromLibrary,
    GetAllBook,
    deleteBook
}