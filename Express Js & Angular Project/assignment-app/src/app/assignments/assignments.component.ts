import { Component, OnInit } from '@angular/core';
import { AssignmentService } from '../assignment.service';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-assignments',
  templateUrl: './assignments.component.html',
  styleUrls: ['./assignments.component.css']
})
export class AssignmentsComponent implements OnInit {

  title:String = "Gestion des assignments"


  constructor(private assignmentService: AssignmentService) {}


  ngOnInit(): void {

  }




}



