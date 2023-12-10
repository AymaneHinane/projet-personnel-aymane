const express = require("express")
const router =  express.Router();
const roleController = require("../controllers/rolecontroller.js")



router.post('/',roleController.AddRole)

module.exports = router;