import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateAssignmentsformComponent } from './update-assignmentsform.component';

describe('UpdateAssignmentsformComponent', () => {
  let component: UpdateAssignmentsformComponent;
  let fixture: ComponentFixture<UpdateAssignmentsformComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UpdateAssignmentsformComponent]
    });
    fixture = TestBed.createComponent(UpdateAssignmentsformComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
