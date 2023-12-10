import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TranferDetailsManagementUpdateComponent } from './tranfer-details-management-update.component';

describe('TranferDetailsManagementUpdateComponent', () => {
  let component: TranferDetailsManagementUpdateComponent;
  let fixture: ComponentFixture<TranferDetailsManagementUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TranferDetailsManagementUpdateComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TranferDetailsManagementUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
