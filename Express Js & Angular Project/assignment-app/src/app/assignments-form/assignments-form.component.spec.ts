import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssignmentsFormComponent } from './assignments-form.component';

describe('AssignmentsFormComponent', () => {
  let component: AssignmentsFormComponent;
  let fixture: ComponentFixture<AssignmentsFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AssignmentsFormComponent]
    });
    fixture = TestBed.createComponent(AssignmentsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
