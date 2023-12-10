import { Injectable, OnInit } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Assignment } from './assignment.model';
import { AssignmentServiceApiService } from './assignment-service-api.service';

@Injectable({
  providedIn: 'root'
})
export class AssignmentService implements OnInit {


  private assignmentsSubject = new BehaviorSubject<Assignment[]>([]);

  assignments$: Observable<Assignment[]> = this.assignmentsSubject.asObservable();

  private selectedassignmentsSubject = new BehaviorSubject<string>("");
  selectedassignments$: Observable<string> = this.selectedassignmentsSubject.asObservable();

  constructor(private assignmentServiceApiService: AssignmentServiceApiService) {}

  ngOnInit(): void {
  }

  getAssignments(): Assignment[] {
    return this.assignmentsSubject.value;
  }

  // getAssignmentById(id:string):Assignment{
  //   this.assignmentServiceApiService.getAssignmentById(id).subscribe((assignment:Assignment)=>{
  //     console.log(assignment);
  //       return assignment;
  //   })

  //   return  {
  //     _id:"",
  //     nom:"",
  //     description:"",
  //     date_rendu:new Date(),
  //     rendu:false
  //   }
   
  // }

  searchAssignments():void{
   // this.assignmentsSubject.next(assignments)
   this.assignmentServiceApiService.getAllAssignments().subscribe((assignments: Assignment[]) => {
    console.log("Assignments fetched:", assignments);
      this.assignmentsSubject.next(assignments)// Update the assignments in the service
  });
  }

  addAssignments(assignments: Assignment):void{
    console.log(assignments);
    this.assignmentServiceApiService.createAssignment(assignments).subscribe(()=>{
      this.searchAssignments();
    })
  }

  updateAssignments(assignmentId:string,assignment: Assignment): void {
    this.assignmentServiceApiService.updateAssignment(assignmentId,assignment).subscribe(()=>{
      this.searchAssignments();
    })
   // this.assignmentsSubject.next(assignments);
  }

  getSelectedAssignments(){
    return this.selectedassignmentsSubject.value;
  }

  updateSelectedAssignments(id:string){
    console.log(id);
    this.selectedassignmentsSubject.next(id);
  }

  deleteAssignment(id:string){
     this.assignmentServiceApiService.deleteAssignment(id).subscribe(()=>{
         this.searchAssignments();
     })
  }



}
