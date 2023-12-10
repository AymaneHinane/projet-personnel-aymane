import { TestBed } from '@angular/core/testing';

import { TransferFilterService } from './transfer-filter.service';

describe('TransferFilterService', () => {
  let service: TransferFilterService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TransferFilterService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
