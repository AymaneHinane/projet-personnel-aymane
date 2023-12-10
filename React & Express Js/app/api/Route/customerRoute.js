const express  = require("express");
const router = express.Router();
const ROLES_LIST = require('../Data/RolesData')
const verifyRoles = require('../middleware/verifyRoles')
const CustomerController = require('../controllers/customercontroller')


router.get("/",verifyRoles(ROLES_LIST.Admin,ROLES_LIST.Employee),CustomerController.GetAllCustomer);
router.get("/:id",verifyRoles(ROLES_LIST.Admin,ROLES_LIST.Employee),CustomerController.GetCustomer);

//router.post("/",verifyRoles(ROLES_LIST.Admin),CustomerController.addCustomer);

router.put("/:id",verifyRoles(ROLES_LIST.Admin,ROLES_LIST.Employee),CustomerController.UpdateCustomer);
router.delete("/:id",verifyRoles(ROLES_LIST.Admin),CustomerController.deleteCustomer);
router.put("/role/:id",verifyRoles(ROLES_LIST.Admin),CustomerController.UpdateRole);

module.exports = router;



