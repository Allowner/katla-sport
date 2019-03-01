import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HiveSectionProductListItem } from '../models/hive-section-product-list-item';
import { HiveSectionProductService } from '../services/hive-section-product.service';

@Component({
  selector: 'app-forwarder-list',
  templateUrl: './forwarder-list.component.html',
  styleUrls: ['./forwarder-list.component.css']
})
export class ForwarderListComponent implements OnInit {

  hiveSectionProducts: Array<HiveSectionProductListItem>;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private hiveSectionProductService: HiveSectionProductService
  ) { }

  ngOnInit() {
    this.hiveSectionProductService.getItems().subscribe(h => this.hiveSectionProducts = h);
  }

  filterItems(){
    if (this.hiveSectionProducts != undefined)
    {
      return this.hiveSectionProducts.filter(x => x.isDelivered == false);
    }
  }

  onDeliver(itemId: number) {
    var item = this.hiveSectionProducts.find(h => h.id == itemId);
    this.hiveSectionProductService.setItemDeliveredStatus(itemId, true).subscribe(c => item.isDelivered = true);
  }
}