const express = require("express")
const router =  express.Router();
const authcontroller = require("../controllers/authcontroller.js")
const verifyJWT = require("../middleware/verifyJWT.js")


console.log("authroute");
console.log(0);
router.post('/register',authcontroller.register)

router.post('/login',authcontroller.login)

router.get('/refresh',authcontroller.refreshToken)

router.get('/logout',authcontroller.logout)

router.get('/profile',authcontroller.profile)

module.exports = router;