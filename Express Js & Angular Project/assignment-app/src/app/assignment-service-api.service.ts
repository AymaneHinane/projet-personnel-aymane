import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Assignment } from './assignment.model';
import { Student } from './student.model';

@Injectable({
  providedIn: 'root'
})
export class AssignmentServiceApiService {

  private apiUrl = 'http://localhost:3000/assignments';

  constructor(private http: HttpClient) {}

  // Create Assignment
  createAssignment(assignmentData: Assignment): Observable<Assignment> {
    return this.http.post<Assignment>(this.apiUrl, assignmentData);
  }

  // Update Assignment
  updateAssignment(assignmentId: string, assignmentData: Assignment): Observable<Assignment> {
    const url = `${this.apiUrl}/${assignmentId}`;
    return this.http.put<Assignment>(url, assignmentData);
  }

  // Delete Assignment
  deleteAssignment(assignmentId: string): Observable<Assignment> {
    const url = `${this.apiUrl}/${assignmentId}`;
    return this.http.delete<Assignment>(url);
  }

  // Get All Assignments
  getAllAssignments(): Observable<Assignment[]> {
    return this.http.get<Assignment[]>(this.apiUrl);
  }

  // Get Assignment by ID
  getAssignmentById(assignmentId: string): Observable<Assignment> {
    const url = `${this.apiUrl}/${assignmentId}`;
    return this.http.get<Assignment>(url);
  }


  getStudents(): Observable<Student[]> {
    return this.http.get<Student[]>(`http://localhost:3000/users`);
}



}
