import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { HiveSectionListItem } from '../models/hive-section-list-item';
import { HiveSectionProductListItem } from '../models/hive-section-product-list-item';

@Injectable({
  providedIn: 'root'
})
export class HiveSectionProductService {
  private url = environment.apiUrl + 'api/items/';

  constructor(private http: HttpClient) { }

  getItems(): Observable<Array<HiveSectionProductListItem>> {
    return this.http.get<Array<HiveSectionProductListItem>>(this.url);
  }

  getItem(itemId: number): Observable<HiveSectionProductListItem> {
    return this.http.get<HiveSectionProductListItem>(`${this.url}${itemId}`);
  }

  addItem(item: HiveSectionProductListItem): Observable<HiveSectionProductListItem> {
    return this.http.post<HiveSectionProductListItem>(`${this.url}`, item);
  }

  updateItem(item: HiveSectionProductListItem): Observable<Object> {
    return this.http.put<HiveSectionProductListItem>(`${this.url}${item.id}`, item);
  }

  deleteItem(itemId: number): Observable<Object> {
    return this.http.delete<HiveSectionProductListItem>(`${this.url}${itemId}`);
  }

  setItemStatus(itemId: number, deletedStatus: boolean): Observable<Object> {
    return this.http.put(`${this.url}${itemId}/status/${deletedStatus}`, deletedStatus);
  }

  setItemDeliveredStatus(itemId: number, deliveredStatus: boolean): Observable<Object> {
    return this.http.put(`${this.url}${itemId}/deliveredStatus/${deliveredStatus}`, deliveredStatus);
  }
}
