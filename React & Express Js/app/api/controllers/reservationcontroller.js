const { response } = require('express');
const Reservation = require('../models/Reservation');



const AddReservation = async (req, res) => {

    //   const TotalQuantity = ProductLibrary.aggregate(
    //     [
    //         { $match: { renderDate: req.body.user } },
    //         { $group: { _id: "$customerName", totalAmount: { $sum: "$totalAmount" } } }
    //       ]
    //   )

    const NoReturn = await Reservation.findOne({
        user: req.body.user,
        // took:true,
        return: false
    })

    if (NoReturn)
        return res.status(405).json({ err: 'vous aviez un livre non rendue' })


    //++++++++++++++++++++++++++++++++++++++++++++++
       const getBook  = await Reservation.findOne({
          user:req.body.user,
          product:req.body.product
       }).sort({"reservationDate":-1}).limit(1)


       console.log(getBook);
       if(getBook)
       {
        var dateblock = new Date(getBook.renderDate);
        dateblock.setDate(dateblock.getDate() + 60);

        if(new Date() < dateblock)
          return res.status(405).json({ err: 'vous ne pouver pas reserver se livre pour l\'instant' })
       }
      
    //++++++++++++++++++++++++++++++++++++++++++++++   


    var result = new Date();
    result.setDate(result.getDate() + 30);

    const reservation = {
        reservationDate: new Date(),
        takeDate:null,
        RenderAfterTake:null,
        renderDate: result,
        user: req.body.user,
        product: req.body.product,
        library: req.body.product,
        took: false,
        return: false
    }

    const data = await Reservation.create(reservation);

    res.status(200).json(data)
    try {

    } catch (err) {
        res.status(500).json();
    }
}


const GetAllReservation = async (req,res)=>{
     console.log('here 1');
    try{
      const data = await Reservation.find()
                     .populate('user')
                     .populate('product')
   
      res.status(200).json(data)

    }catch(err){
        res.status(500).json(err)
    }
}

const GetReservationById = async (req,res) =>{

    try{
         const data  = await Reservation.findOne({_id:req.params.id})
                     .populate('user')
                     .populate('product')

          res.status(200).json(data);

    }catch(err){
          res.status(500).json(err)
    }
}

const UpdateReseservation = async (req,res)=>{
    try{
       const data  = await Reservation.findOneAndUpdate({_id:req.params.id},req.body)
       res.status(200).json(data)
    }catch(err){
       res.status(500).json();
    }
}


const DeleteReservation = async (req,res) =>{
    try{
        const data  = await Reservation.findOneAndDelete(req.params.id)
        res.status(200).json(data)
    }catch(err){
        res.status(500).json();
    }
}


module.exports = {
    AddReservation,
    GetAllReservation,
    GetReservationById,
    UpdateReseservation,
    DeleteReservation
}