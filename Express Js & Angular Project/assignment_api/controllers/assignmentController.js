// controllers/assignmentController.js

const Assignment = require('../models/assingnmentModel.js'); //models/assingnments.js
const User = require('../models/userModel');





// Controller to create a new assignment
exports.createAssignment = async (req, res) => {
  try {
    const { nom, description, date_rendu, rendu } = req.body;
    const assignment = new Assignment({
      nom,
      description,
      date_rendu,
      rendu,
    });
    const savedAssignment = await assignment.save();
    res.status(201).json(savedAssignment);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
};

// Controller to get all assignments
exports.getAllAssignments = async (req, res) => {
  try {
    const assignments = await Assignment.find().sort({ date_rendu: 'desc' });;
    console.log("hello 1");
    res.status(200).json(assignments);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
};

// Controller to get a specific assignment by ID
exports.getAssignmentById = async (req, res) => {
  try {
    const assignment = await Assignment.findById(req.params.id);
    if (!assignment) {
      return res.status(404).json({ message: 'Assignment not found' });
    }
    res.status(200).json(assignment);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
};

// Controller to update an assignment by ID
exports.updateAssignmentById = async (req, res) => {
  try {
    const updatedAssignment = await Assignment.findByIdAndUpdate(
      req.params.id,
      req.body,
      { new: true }
    );
    if (!updatedAssignment) {
      return res.status(404).json({ message: 'Assignment not found' });
    }
    res.status(200).json(updatedAssignment);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
};

// Controller to delete an assignment by ID
exports.deleteAssignmentById = async (req, res) => {
  try {
    const deletedAssignment = await Assignment.findByIdAndDelete(req.params.id);
    if (!deletedAssignment) {
      return res.status(404).json({ message: 'Assignment not found' });
    }
    res.status(200).json({ message: 'Assignment deleted successfully' });
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
};




