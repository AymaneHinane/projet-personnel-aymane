const mongoose = require('mongoose');
const {Schema} = mongoose;

const RoleSchema = new Schema({
    role:String,
})


const RoleModel =mongoose.model('Role',RoleSchema);

module.exports = RoleModel;