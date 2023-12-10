import { Component, OnInit } from '@angular/core';
import { AssignmentService } from '../assignment.service';
import { Assignment } from '../assignment.model';
import { AssignmentServiceApiService } from '../assignment-service-api.service';

@Component({
  selector: 'app-update-assignmentsform',
  templateUrl: './update-assignmentsform.component.html',
  styleUrls: ['./update-assignmentsform.component.css']
})
export class UpdateAssignmentsformComponent implements OnInit {

  updatedAssignment: Assignment = {
    _id:"",
    nom:"",
    description:"",
    date_rendu:new Date(),
    rendu:false
  };

  selectedAssign = ""

  constructor(private assignmentService: AssignmentService,private assignmentServiceApiService:AssignmentServiceApiService){

  }

  ngOnInit(): void {
    //    this.assignmentService.selectedassignments$.subscribe((selected) => {
    //     console.log('here');
    //    console.log(selected);
    //    this.selectedAssign = selected
    //    this.updatedAssignment = this.assignmentService.getAssignmentById(this.selectedAssign);
    //    console.log(this.updatedAssignment);
    // });

    this.assignmentService.selectedassignments$.subscribe((selected) => {
        this.selectedAssign = selected
        this.assignmentServiceApiService.getAssignmentById(this.selectedAssign).subscribe((assignment:Assignment)=>{
          this.updatedAssignment = assignment;   
        })
    })
  }

 
  getSelectedAssignment(selected:string){
    var currentAssignments = this.assignmentService.getAssignments();

    var selectedAssignments = currentAssignments.filter(x=>x.nom == selected)[0]
    this.updatedAssignment.nom = selectedAssignments["nom"];
    this.updatedAssignment.date_rendu = selectedAssignments["date_rendu"];
    this.updatedAssignment.rendu = selectedAssignments["rendu"];

  }


  updateAssignment(){
      
    //var currentAssignments = this.assignmentService.getAssignments();

   // var newAssignments  = currentAssignments.filter(x=>x.nom != this.selectedAssign)

   // this.assignmentService.updateAssignments([...newAssignments,this.updatedAssignment]);

    this.assignmentService.updateAssignments(this.selectedAssign,this.updatedAssignment);

     this.updatedAssignment = {
      _id:"",
      nom:"",
      description:"",
      date_rendu:new Date(),
      rendu:false
    };
  }

}


