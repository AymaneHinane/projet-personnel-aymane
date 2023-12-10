

const User = require('../models/User')


const deleteCustomer = async (req,res)=>{

    try{
      await User.findByIdAndDelete(req.params.id);
      res.sendStatus(200);
    }catch(err)
    {
       res.status(500).json(err);
    }
}

const UpdateCustomer = async (req,res)=>{
   
    User.findByIdAndUpdate(req.params.id,req.body)
    .then (result=>res.status(200).json(result))
    .catch (error=>res.status(500).json(error)); 
}

const GetAllCustomer = async (req,res)=>{
   
    User.find()
    .then (result=>res.status(200).json(result))
    .catch (error=>res.status(500).json(error)); 
}

const GetCustomer = async (req,res)=>{
   
    User.findById(req.params.id)
    .then (result=>res.status(200).json(result))
    .catch (error=>res.status(500).json(error)); 
}

const UpdateRole = async (req,res)=>{

    console.log('update role');

      const data  = await User.findOne({_id:req.params.id,roles:{ $in : "admin" }});
      
      if(data)
         return res.status(402).json({err:"le role admin ne peut pas etre modifier pour ce user"})
        
      User.findByIdAndUpdate(req.params.id,{roles:req.body.roles})
      .then (result=>res.status(200).json(result))
      .catch (error=>res.status(500).json(error)); 
}


module.exports = {
    deleteCustomer,
    UpdateCustomer,
    GetAllCustomer,
    GetCustomer,
    UpdateRole
}