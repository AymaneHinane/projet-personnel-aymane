const express  = require("express");
const router = express.Router();
const ROLES_LIST = require('../Data/RolesData')
const verifyRoles = require('../middleware/verifyRoles')

const ReservationControler = require('../controllers/reservationcontroller');


router.post('/',verifyRoles(ROLES_LIST.User),ReservationControler.AddReservation);
router.get('/',verifyRoles(ROLES_LIST.Admin,ROLES_LIST.Employee),ReservationControler.GetAllReservation)
router.get('/:id',verifyRoles(ROLES_LIST.Admin,ROLES_LIST.Employee),ReservationControler.GetReservationById)
router.put('/:id',verifyRoles(ROLES_LIST.Admin,ROLES_LIST.Employee),ReservationControler.UpdateReseservation)
router.delete('/:id',verifyRoles(ROLES_LIST.Admin,ROLES_LIST.Employee),ReservationControler.DeleteReservation)

module.exports = router;