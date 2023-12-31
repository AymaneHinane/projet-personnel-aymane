import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InventoryManagementFormComponent } from './inventory-management-form.component';

describe('InventoryManagementFormComponent', () => {
  let component: InventoryManagementFormComponent;
  let fixture: ComponentFixture<InventoryManagementFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InventoryManagementFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InventoryManagementFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
