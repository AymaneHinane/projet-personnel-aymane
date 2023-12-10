import { TestBed } from '@angular/core/testing';

import { AssignmentServiceApiService } from './assignment-service-api.service';

describe('AssignmentServiceApiService', () => {
  let service: AssignmentServiceApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AssignmentServiceApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
