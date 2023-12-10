import { Component, Input, OnInit } from '@angular/core';
import { AssignmentService } from '../assignment.service';
import { MatTableDataSource } from '@angular/material/table';
import { Assignment } from '../assignment.model';
import { AssignmentServiceApiService } from '../assignment-service-api.service';
import { Router } from '@angular/router';




@Component({
  selector: 'app-assignment-table',
  templateUrl: './assignment-table.component.html',
  styleUrls: ['./assignment-table.component.css']
})
export class AssignmentTableComponent implements OnInit {

  @Input() state:string='delete';

  assignments: Assignment[] = []

  displayedColumns: string[] = ['Nom', 'DateRendu', 'Rendu', 'actions'];
  dataSource!: MatTableDataSource<Assignment>;

  constructor(private assignmentService: AssignmentService,private assignmentServiceApiService: AssignmentServiceApiService,private router: Router){

  }

  ngOnInit() {
    this.assignmentService.searchAssignments()

    this.assignmentService.assignments$.subscribe((assignments) => {
      this.assignments = assignments;
    });
    this.assignmentService.assignments$.subscribe((assignments) => {

      this.dataSource = new MatTableDataSource(assignments);
    });
  }

  deleteAssignments(id:string){
    
    this.assignmentService.deleteAssignment(id);
    
 }

 updateSelectedAssignment(id:string){
    console.log(id);
     this.assignmentService.updateSelectedAssignments(id);
 }


 viewAssignmentInfo(assignmentId: string): void {
  // Navigate to AssignmentInfoComponent with assignment ID as route parameter
  this.router.navigate(['/assignment-info', assignmentId]);
}


  

}
