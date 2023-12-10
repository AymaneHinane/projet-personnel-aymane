const User = require('../models/User')
const jwt = require('jsonwebtoken')
require('dotenv').config();
const bcrypt = require('bcryptjs');
const { json } = require('express');
const { use } = require('../Route/authRoute');
const bcryptSalt = bcrypt.genSaltSync(10);





const register = async (req, res) => {

    const { name, email, password ,phone , roles } = req.body;

  try {

        if (!(email && password && name && phone && roles)) {
            return res.status(400).send("All input is required");
        }
         
        console.log("authcontroller register");
        console.log(1);
        const oldUser = await User.findOne({ email });

        console.log("authcontroller register");
        console.log(2);
        if (oldUser) {
            return res.status(409).send("User Already Exist. Please Login");
          }

        const user = await User.create({
            name,
            email,
            password: bcrypt.hashSync(password, bcryptSalt),
            phone,
            refreshToken:'',
            roles:roles
        });
 
        return res.status(200).json(user)
        
    } catch (err) {

        return res.status(500).json(err)
    }

}



const login = async (req, res) => {

    console.log("authcontroller login");
    console.log(7);
    const { email, password } = req.body;
    console.log(email);
    const UserSearch = await User.findOne({email});
    console.log("authcontroller login");
    console.log(UserSearch);
    console.log(8);
    if (UserSearch) {        
        const passOK = bcrypt.compareSync(password, UserSearch.password);
        if (passOK) {
            console.log("authcontroller login");
            console.log(9);
            const accessToken = jwt.sign(
               // { email: UserSearch.email, id: UserSearch._id, name: UserSearch.name },
               {UserInfo:
                { email: UserSearch.email, id: UserSearch._id, name: UserSearch.name,roles:UserSearch.roles }
               },
                process.env.ACCESS_TOKEN_SECRET,
                { expiresIn: '1h' }
            );
            console.log("authcontroller login");
            console.log(10);
            const refreshToken = jwt.sign(
                { email: UserSearch.email, id: UserSearch._id, name: UserSearch.name,roles:UserSearch.roles },
                process.env.REFRESH_TOKEN_SECRET,
                { expiresIn: '30d' }
            );
            console.log("authcontroller login");
            console.log(11);
             await User.findOneAndUpdate({email:email}, { refreshToken: refreshToken }).then((user) => {
                // sameSite:'None', secure:true, 
                res.cookie('jwt', refreshToken, { httpOnly: true,maxAge: 24 * 60 * 60 * 1000 });
                return res.json({ accessToken,roles:user.roles });

                }).catch(err => {
                    return res.status(500);
                });
                console.log("authcontroller login");
                console.log(12);
        }
        else{
            return res.status(422).json('error');
        }
    } else {
        return res.status(404).json('not found');
    }
}


const refreshToken = async (req,res)=>{

    if (req.cookies?.jwt) {

        console.log("authcontroller refresh");
        console.log(4);
        // Destructuring refreshToken from cookie
        const refreshToken = req.cookies.jwt;
        console.log(refreshToken);
        console.log('4.1');

        // Verifying refresh token
        jwt.verify(refreshToken, process.env.REFRESH_TOKEN_SECRET, 
        async (err, decoded) => {
            console.log(decoded);
            if (err) {

                // Wrong Refesh Token
                return res.status(406).json({ message: 'Unauthorized' });
            }
            else {

                const accessToken = jwt.sign({
                    UserInfo:
                        { email: decoded.email, id: decoded._id, name: decoded.name,roles:decoded.roles }                      
                    }, process.env.ACCESS_TOKEN_SECRET, {
                       expiresIn: '1h'
                    });
                    console.log("authcontroller refresh");
                    console.log(6);
                    console.log(accessToken);
                    return res.status(200).json({ accessToken });
            }
        })
    } else {
        return res.status(406).json({ message: 'Unauthorized' });
    }

}


const logout  = async (req,res)=>{

    console.log('deconnexion 1');
    if (req.cookies?.jwt) {

        console.log('deconnexion 2');

            await User.findOneAndUpdate({ refreshToken: req.cookies.jwt }, { refreshToken: "" }).then((user) => {
                console.log(user);
                res.clearCookie('jwt', { httpOnly: true,  maxAge: 24 * 60 * 60 * 1000 } )

                return res.sendStatus(204);
    
                }).catch(err => {
                    return res.sendStatus(500);
                });
       
    } else {
        return res.sendStatus(204);
    }

}

const profile = (req,res)=>{
    
    if(req.cookies.jwt)
        {
             jwt.verify(req.cookies.jwt,process.env.REFRESH_TOKEN_SECRET,(err,user)=>{
                if(err) throw err;
                return res.json(user);
             })
        }else{
            return  res.status(500).json({err:'profile not found'});
        }
}



module.exports =
{
    register,
    login,
    refreshToken,
    logout,
    profile
}
