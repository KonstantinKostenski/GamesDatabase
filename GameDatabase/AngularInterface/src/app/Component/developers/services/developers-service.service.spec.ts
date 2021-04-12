import { TestBed } from '@angular/core/testing';
import { DevelopersServiceService } from './developers-service.service';

describe('DevelopersServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DevelopersServiceService = TestBed.get(DevelopersServiceService);
    expect(service).toBeTruthy();
  });
});
