import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { HiveSection } from '../models/hive-section';
import { HiveSectionListItem } from '../models/hive-section-list-item';
import { HiveSectionProductListItem } from '../models/hive-section-product-list-item';

@Injectable({
  providedIn: 'root'
})
export class HiveSectionProductService {
  private url = environment.apiUrl + 'api/sectionProducts/';

  constructor(private http: HttpClient) { }
}
