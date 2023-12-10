
const express  = require("express");
const router = express.Router();
const catalogueController = require("../controllers/productcontroller");
const ROLES_LIST = require('../Data/RolesData')
const verifyRoles = require('../middleware/verifyRoles')



router.get("/category",verifyRoles(ROLES_LIST.Admin,ROLES_LIST.Employee),catalogueController.getCategory);

router.post("/category",verifyRoles(ROLES_LIST.Admin,ROLES_LIST.Employee), catalogueController.addCategory);

router.get("/filter?:name?:category",verifyRoles(ROLES_LIST.Admin,ROLES_LIST.Employee),catalogueController.GetProductByFiltre);


router.post("/",verifyRoles(ROLES_LIST.Admin,ROLES_LIST.Employee),catalogueController.AddProduct);

router.get("/",verifyRoles(ROLES_LIST.Admin,ROLES_LIST.Employee),catalogueController.getAllProducts);

router.get("/:id",verifyRoles(ROLES_LIST.Admin,ROLES_LIST.Employee),catalogueController.getProductById);

router.delete("/image?:idProduct?:idImage",verifyRoles(ROLES_LIST.Admin,ROLES_LIST.Employee),catalogueController.deleteImageById); 

router.delete("/:id",verifyRoles(ROLES_LIST.Admin,ROLES_LIST.Employee),catalogueController.deleteProductById);

router.put("/:id",verifyRoles(ROLES_LIST.Admin,ROLES_LIST.Employee),catalogueController.updateProductById);

router.post("/:idP/category/:idC",verifyRoles(ROLES_LIST.Admin,ROLES_LIST.Employee),catalogueController.AddProductCategory);


module.exports = router;