import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TranferDetailsManagementFormComponent } from './tranfer-details-management-form.component';

describe('TranferDetailsManagementFormComponent', () => {
  let component: TranferDetailsManagementFormComponent;
  let fixture: ComponentFixture<TranferDetailsManagementFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TranferDetailsManagementFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TranferDetailsManagementFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
