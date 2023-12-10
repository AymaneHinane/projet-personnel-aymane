import { Component, OnInit } from '@angular/core';
import { Student } from '../student.model';
import { AssignmentServiceApiService } from '../assignment-service-api.service';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-student-table',
  templateUrl: './student-table.component.html',
  styleUrls: ['./student-table.component.css']
})
export class StudentTableComponent implements OnInit {


  displayedColumns: string[] = ['username', 'role']; // Add or remove columns as needed
  dataSource: MatTableDataSource<Student>;

  //@ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  constructor(private assignmentServiceApiService: AssignmentServiceApiService) {
    this.dataSource = new MatTableDataSource<Student>();
  }

  ngOnInit(): void {
    this.assignmentServiceApiService.getStudents().subscribe((students: Student[]) => {
      this.dataSource.data = students;
    });
  }



}
