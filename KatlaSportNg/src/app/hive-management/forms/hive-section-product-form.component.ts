import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HiveSectionProductListItem } from '../models/hive-section-product-list-item';
import { HiveSectionListItem } from '../models/hive-section-list-item';
import { HiveSectionService } from '../services/hive-section.service';
import { HiveSectionProductService } from '../services/hive-section-product.service';
import { log } from 'util';

@Component({
    selector: 'app-hive-section-product-form',
    templateUrl: './hive-section-product-form.component.html',
    styleUrls: ['./hive-section-product-form.component.css']
  })
  export class HiveSectionProductFormComponent implements OnInit {
  
    hiveSectionProduct = new HiveSectionProductListItem(0, 0, 0, false, false, 0);
    existed = false;
    hiveSections: HiveSectionListItem[];
  
    constructor(
      private route: ActivatedRoute,
      private router: Router,
      private hiveSectionService: HiveSectionService,
      private hiveSectionProductService: HiveSectionProductService
    ) { }
  
    ngOnInit() {
      this.hiveSectionService.getHiveSections().subscribe(c => this.hiveSections = c);
      this.route.params.subscribe(p => {
        this.hiveSectionProduct.hiveSectionId = p['hiveSectionId'];
        if (p['id'] === undefined) {
          return;
        }
        this.hiveSectionProductService.getItem(p['id']).subscribe(h => this.hiveSectionProduct = h);
        this.existed = true;
      });
    }

    navigateToProducts() {
      this.router.navigate([`/section/${this.hiveSectionProduct.hiveSectionId}/products`]);
    }

    onSubmit() {
      if (this.existed) {
        this.hiveSectionProductService.updateItem(this.hiveSectionProduct).subscribe(c => this.navigateToProducts());
      } else {
        this.hiveSectionProductService.addItem(this.hiveSectionProduct).subscribe(c => this.navigateToProducts());
      }
    }

    onDelete() {
      this.hiveSectionProductService.setItemStatus(this.hiveSectionProduct.id, true).subscribe(c => this.hiveSectionProduct.isDeleted = true);
    }
    
    onUndelete() {
      this.hiveSectionProductService.setItemStatus(this.hiveSectionProduct.id, false).subscribe(c => this.hiveSectionProduct.isDeleted = false);
    }

    onDeliveryWait() 
    {
      this.hiveSectionProductService.setItemDeliveredStatus(this.hiveSectionProduct.id, true).subscribe(c => this.hiveSectionProduct.isDelivered = true);
    }
      
    onDelivery() 
    {
      this.hiveSectionProductService.setItemDeliveredStatus(this.hiveSectionProduct.id, false).subscribe(c => this.hiveSectionProduct.isDelivered = false);
    }
    
    onPurge() {
      this.hiveSectionProductService.deleteItem(this.hiveSectionProduct.id).subscribe(c => this.navigateToProducts());
    }
}