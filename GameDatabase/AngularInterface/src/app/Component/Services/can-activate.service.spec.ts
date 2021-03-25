import { TestBed } from '@angular/core/testing';
import { CanActivatePath } from './can-activate.service';


describe('CanActivateService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CanActivatePath = TestBed.get(CanActivatePath);
    expect(service).toBeTruthy();
  });
});
