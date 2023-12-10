
const verifyRoles = (...allowedRoles)=>{
    console.log("verifyRoles");
    console.log(17);
    return (req,res,next) => {
     if(!req?.roles) return  res.sendStatus(401);
      const rolesArray = [...allowedRoles];
      console.log(rolesArray);
       console.log(req.roles)
      const result = req.roles.map(role => rolesArray.includes(role)).find(val => val === true);
      console.log(result);

      if (!result)
      {
        console.log("verifyRoles");
        console.log("result 1");
        return res.sendStatus(401);//res.status(401).json("you don't have the permition")//
      }
      console.log("verifyRoles");
      console.log(18);
      next();
    }
}

module.exports = verifyRoles;