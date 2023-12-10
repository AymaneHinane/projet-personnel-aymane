const mongoose = require("mongoose");

const ReservationSchema  = new mongoose.Schema({

    reservationDate:Date,
    takeDate:Date,
    renderDate:Date,
    RenderAfterTake:Date,
    user:{
        type: mongoose.Types.ObjectId,
        ref:"User"
    },
    product:{
        type: mongoose.Types.ObjectId,
        ref:"Product"
    },
    took:Boolean,
    return:Boolean

});

const Reservation = mongoose.model("Reservation",ReservationSchema);

module.exports = Reservation;