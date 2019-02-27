import { TestBed, inject } from '@angular/core/testing';

import { HiveSectionProductService } from './hive-section-product.service';

describe('HiveSectionProductService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [HiveSectionProductService]
    });
  });

  it('should be created', inject([HiveSectionProductService], (service: HiveSectionProductService) => {
    expect(service).toBeTruthy();
  }));
});
