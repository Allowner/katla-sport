import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HiveSectionProductListItem } from '../models/hive-section-product-list-item';
import { HiveSectionProductService } from '../services/hive-section-product.service';
import { HiveSectionService } from '../services/hive-section.service';
import { HiveSection } from '../models/hive-section';

@Component({
  selector: 'app-hive-section-product-list',
  templateUrl: './hive-section-product-list.component.html',
  styleUrls: ['./hive-section-product-list.component.css']
})
export class HiveSectionProductListComponent implements OnInit {

  hiveSectionId: number;
  section: HiveSection
  hiveSectionProducts: Array<HiveSectionProductListItem>;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private hiveSectionProductService: HiveSectionProductService,
    private hiveSectionService: HiveSectionService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(p => {
      this.hiveSectionId = p['hiveSectionId'];
      this.hiveSectionService.getItems(this.hiveSectionId).subscribe(s => this.hiveSectionProducts = s);
    })

    this.hiveSectionService.getHiveSection(this.hiveSectionId).subscribe(data => this.section = data);
  }

  back() {
    this.router.navigate([`/hive/${this.section.storeHiveId}/sections`]);
  }

  onAdd() {
    this.router.navigate([`/section/${this.hiveSectionId}/item`]);
  }

  onDelete(itemId: number) {
    var item = this.hiveSectionProducts.find(h => h.id == itemId);
    this.hiveSectionProductService.setItemStatus(itemId, true).subscribe(c => item.isDeleted = true);
  }

  onUndelete(itemId: number){
    var item = this.hiveSectionProducts.find(h => h.id == itemId);
    this.hiveSectionProductService.setItemStatus(itemId, false).subscribe(c => item.isDeleted = false);
  }
}