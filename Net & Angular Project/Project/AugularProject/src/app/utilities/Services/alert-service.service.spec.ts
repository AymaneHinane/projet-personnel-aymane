import { TestBed } from '@angular/core/testing';

import { AlertServiceService } from './alert-service.service';

describe('UtilitiesServiceService', () => {
  let service: AlertServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AlertServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
