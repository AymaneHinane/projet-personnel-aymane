import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Assignment } from '../assignment.model';
import { AssignmentServiceApiService } from '../assignment-service-api.service';

@Component({
  selector: 'app-assignment-info',
  templateUrl: './assignment-info.component.html',
  styleUrls: ['./assignment-info.component.css']
})
export class AssignmentInfoComponent {

  assignmentId: string|null = null;

  assignment:Assignment|null=null;

  constructor(private assignmentServiceApiService:AssignmentServiceApiService,private route: ActivatedRoute) {}

  ngOnInit(): void {
    // Retrieve assignmentId from the route parameters
    this.assignmentId = this.route.snapshot.paramMap.get('id');

    console.log(this.assignmentId);

   if(this.assignmentId){
     this.assignmentServiceApiService.getAssignmentById(this.assignmentId).subscribe((assignment:Assignment)=>{
      this.assignment = assignment;
      console.log(this.assignment);
     });
    
   }



  }




}


