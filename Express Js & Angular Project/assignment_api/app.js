// app.js

const express = require('express');
const mongoose = require('mongoose');
const assignmentController = require('./controllers/assignmentController');
const userController = require('./controllers/userController');
const authController = require('./controllers/authController');
const cors = require('cors');
const { passport, authenticate } = require('./middlewares/authMiddleware');


const app = express();
const PORT = process.env.PORT || 3000;


app.use(cors());
app.use(express.json());
app.use(passport.initialize());


mongoose.connect('mongodb+srv://aymanehinane:fdalate1964@serverlessinstance0.ip0az.mongodb.net/?retryWrites=true&w=majority', {
  useNewUrlParser: true,
  useUnifiedTopology: true,
});


const db = mongoose.connection;
db.on('error', console.error.bind(console, 'MongoDB connection error:'));
db.once('open', () => {
  console.log('Connected to MongoDB');
});

// Registration and login routes
app.post('/register', authController.register);
app.post('/login', authController.login);

// Routes with role-based authentication middleware
app.post('/assignments', authenticate(['admin']), assignmentController.createAssignment); // admin
app.get('/assignments', authenticate(['user', 'admin']), assignmentController.getAllAssignments); // user admin
app.get('/assignments/:id', authenticate(['user', 'admin']), assignmentController.getAssignmentById); // user admin
app.put('/assignments/:id', authenticate(['admin']), assignmentController.updateAssignmentById); // admin
app.delete('/assignments/:id', authenticate(['admin']), assignmentController.deleteAssignmentById); // admin

app.get('/users', authenticate(['admin']), userController.getAllUsers);



// Start the server
app.listen(PORT, () => {
  console.log(`Server is running on http://localhost:${PORT}`);
});
