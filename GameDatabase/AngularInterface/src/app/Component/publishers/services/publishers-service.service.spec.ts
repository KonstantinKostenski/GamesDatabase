import { TestBed } from '@angular/core/testing';

import { PublishersServiceService } from './publishers-service.service';

describe('PublishersServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PublishersServiceService = TestBed.get(PublishersServiceService);
    expect(service).toBeTruthy();
  });
});
