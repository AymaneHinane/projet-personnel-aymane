const express = require('express');
const app = express();
const cors = require('cors');
const CoockieParser = require('cookie-parser')
const routeAuth = require('./Route/authRoute.js')
const productRoute = require('./Route/productRoute.js')
const roleRoute = require('./Route/roleRoute.js')
const CustomerRoute = require('./Route/customerRoute.js')
const libraryRoute = require('./Route/libraryRoute.js')
const reservationRoute = require('./Route/reservationRoute.js')
const verifyJWT = require('./middleware/verifyJWT.js')
const fs = require('fs');
var path = require('path');
const mongoose = require("mongoose");
const Product = require('./models/Product.js')


require("dotenv").config();
const uri = process.env.MONGO_URL;

app.use(
    cors({
        origin: 'http://localhost:3000',
       // origin: '*',
        credentials: true
    })
)

//mongoose.set("strictQuery", false);

app.use(CoockieParser());
app.use(express.json());

mongoose.connect(uri).then(() => {
    console.log("Database connection established!");

},
    err => {
        {
            console.log("Error connecting Database instance due to:", err);
        }
 });


const multer = require('multer');
const storage = multer.diskStorage({
    destination: function (req, res, cb) {
        cb(null, 'uploads/')
    },

  filename: function (req, file, cb) {
    cb(null, Date.now() + path.extname(file.originalname)) //Appending extension
  }
});

const upload = multer({ storage: storage });
var imgModel = require('./models/Images.js');


app.post('/image', upload.single('image'), (req, res, next) => {
  
console.log(1);

 //console.log( path.extname(path.join(__dirname + '/uploads/' + req.file.filename)).substring(1) )

        var obj = {
            name: req.body.name,
            desc: req.body.desc,
            img: {
                data: fs.readFileSync(path.join(__dirname + '/uploads/' + req.file.filename)),
                //contentType: 'image/png'   
                contentType: `image/${path.extname(path.join(__dirname + '/uploads/' + req.file.filename)).substring(1)}`
            },
            product:req.body.product
        }
        console.log(2);
        imgModel.create(obj, (err, item) => {
               Product.findByIdAndUpdate(req.body.product, { $push: {images:item._id}})
               .then (result=>res.status(200).json(result))
                .catch (error=>res.status(500).json(error));
          //  res.status(200).json(item)
        });

    });
    


app.use('/auth',routeAuth);
app.use('/role',roleRoute);

app.use(verifyJWT);

app.use('/product',productRoute);
app.use('/customer',CustomerRoute);
app.use('/library',libraryRoute);
app.use('/reservation',reservationRoute);

app.listen(4000);
