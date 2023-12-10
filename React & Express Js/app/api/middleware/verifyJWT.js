const jwt = require('jsonwebtoken')
require('dotenv').config();


const verifyJWT  = (req,res,next) => {

    console.log(1);
   // console.log(req.headers);
    const autToken = req.headers.authorization; //req.headers.authorization; // || 
    
    console.log(2)
   // console.log(autToken);
    // if(!authHeader.jwt) return res.sendStatus(401);

    console.log(autToken);
    const token  = autToken.split(' ')[1];
    jwt.verify(
        token,
        process.env.ACCESS_TOKEN_SECRET,
        (err,decoded)=>{
            console.log(2.1);
            if(err) return res.sendStatus(403);
            req.user = decoded.UserInfo.name;
            req.roles = decoded.UserInfo.roles;
            next();
        }
    )
}

module.exports = verifyJWT;