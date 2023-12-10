import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TranferDetailsManagementOverviewComponent } from './tranfer-details-management-overview.component';

describe('TranferDetailsManagementOverviewComponent', () => {
  let component: TranferDetailsManagementOverviewComponent;
  let fixture: ComponentFixture<TranferDetailsManagementOverviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TranferDetailsManagementOverviewComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TranferDetailsManagementOverviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
