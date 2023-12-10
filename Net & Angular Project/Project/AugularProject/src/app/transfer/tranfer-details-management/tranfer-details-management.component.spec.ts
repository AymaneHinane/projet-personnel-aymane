import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TranferDetailsManagementComponent } from './tranfer-details-management.component';

describe('TranferDetailsManagementComponent', () => {
  let component: TranferDetailsManagementComponent;
  let fixture: ComponentFixture<TranferDetailsManagementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TranferDetailsManagementComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TranferDetailsManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
