
const express  = require("express");
const router = express.Router();
const librarycontroller = require('../controllers/librarycontroller');
const ROLES_LIST = require('../Data/RolesData')
const verifyRoles = require('../middleware/verifyRoles')


router.get('/',verifyRoles(ROLES_LIST.Admin,ROLES_LIST.Employee),librarycontroller.GetAllLibrary)
router.post('/',verifyRoles(ROLES_LIST.Admin,ROLES_LIST.Employee),librarycontroller.AddLibrary)

router.post('/:id',verifyRoles(ROLES_LIST.Admin,ROLES_LIST.Employee),librarycontroller.AddProductToLibrary);
router.put('/:id',verifyRoles(ROLES_LIST.Admin,ROLES_LIST.Employee),librarycontroller.UpdateProductQuantity);

router.get('/:idL/product/:idP',verifyRoles(ROLES_LIST.Admin,ROLES_LIST.Employee),librarycontroller.GetProductFromLibrary)
router.get('/:idL/product',verifyRoles(ROLES_LIST.Admin,ROLES_LIST.Employee),librarycontroller.GetAllProductFromLibrary)

router.get('/BookStore',verifyRoles(ROLES_LIST.User,ROLES_LIST.Employee),librarycontroller.GetAllBook);

router.delete('/:idL/product/:idP',verifyRoles(ROLES_LIST.Admin,ROLES_LIST.Employee),librarycontroller.deleteBook)

module.exports = router;