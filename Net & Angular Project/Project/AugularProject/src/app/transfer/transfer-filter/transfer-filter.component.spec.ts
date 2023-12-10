import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransferFilterComponent } from './transfer-filter.component';

describe('TransferFilterComponent', () => {
  let component: TransferFilterComponent;
  let fixture: ComponentFixture<TransferFilterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TransferFilterComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TransferFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
