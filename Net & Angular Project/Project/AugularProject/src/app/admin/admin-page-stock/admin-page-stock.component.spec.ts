import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminPageStockComponent } from './admin-page-stock.component';

describe('AdminPageStockComponent', () => {
  let component: AdminPageStockComponent;
  let fixture: ComponentFixture<AdminPageStockComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminPageStockComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminPageStockComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
