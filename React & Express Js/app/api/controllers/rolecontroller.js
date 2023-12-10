
const Role = require('../models/Role');



const AddRole = async (req,res)=>{
    
 try{
    var newRole = await Role.create(req.body);
    res.status(200).json(newRole);

 }catch(err)
 {
    res.status(500).json(err);
 }
}


module.exports={
    AddRole
}