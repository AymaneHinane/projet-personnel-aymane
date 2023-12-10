import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TranferDetailsManagementTableComponent } from './tranfer-details-management-table.component';

describe('TranferDetailsManagementTableComponent', () => {
  let component: TranferDetailsManagementTableComponent;
  let fixture: ComponentFixture<TranferDetailsManagementTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TranferDetailsManagementTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TranferDetailsManagementTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
