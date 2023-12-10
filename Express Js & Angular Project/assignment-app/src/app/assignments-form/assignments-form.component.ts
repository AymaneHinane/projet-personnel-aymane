import { ChangeDetectorRef, Component } from '@angular/core';
import { AssignmentService } from '../assignment.service';
import { Assignment } from '../assignment.model';

@Component({
  selector: 'app-assignments-form',
  templateUrl: './assignments-form.component.html',
  styleUrls: ['./assignments-form.component.css']
})
export class AssignmentsFormComponent {

  newAssignment: Assignment = {
    _id:"",
    nom:"",
    description:"",
    date_rendu:new Date(),
    rendu:false
  };

  constructor(private assignmentService: AssignmentService) {}

  addAssignment(): void {
    // Add validation if needed
   // const currentAssignments = this.assignmentService.getAssignments();

    this.assignmentService.addAssignments(this.newAssignment);

    this.newAssignment = {
      _id:"",
      nom:"",
      description:"",
      date_rendu:new Date(),
      rendu:true
    };

  }

}
