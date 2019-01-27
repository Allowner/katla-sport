import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HiveSectionService } from '../services/hive-section.service';
import { HiveSection } from '../models/hive-section';
import { HiveListItem } from '../models/hive-list-item';
import { HiveService } from '../services/hive.service';

@Component({
  selector: 'app-hive-section-form',
  templateUrl: './hive-section-form.component.html',
  styleUrls: ['./hive-section-form.component.css']
})
export class HiveSectionFormComponent implements OnInit {

  hiveSection = new HiveSection(0, "", "", false, "", 0);
  existed = false;
  hives: HiveListItem[];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private hiveSectionService: HiveSectionService,
    private hiveService: HiveService
  ) { }

  ngOnInit() {
    this.hiveService.getHives().subscribe(c => this.hives = c);
    this.route.params.subscribe(p => {
      this.hiveSection.storeHiveId = p['hiveId'];
      if (p['id'] === undefined) {
        return;
      }
      this.hiveSectionService.getHiveSection(p['id']).subscribe(h => this.hiveSection = h);
      this.existed = true;
    });
  }

  onCancel() {
    this.navigateToSections();
  }

  navigateToSections() {
    this.router.navigate([`/hive/${this.hiveSection.storeHiveId}/sections`]);
  }
  
  onSubmit() {
    if (this.existed) {
      this.hiveSectionService.updateHiveSection(this.hiveSection).subscribe(c => this.navigateToSections());
    } else {
      this.hiveSectionService.addHiveSection(this.hiveSection).subscribe(c => this.navigateToSections());
    }
  }

  onDelete() {
    this.hiveSectionService.setHiveSectionStatus(this.hiveSection.id, true).subscribe(c => this.hiveSection.isDeleted = true);
  }

  onUndelete() {
    this.hiveSectionService.setHiveSectionStatus(this.hiveSection.id, false).subscribe(c => this.hiveSection.isDeleted = false);
  }

  onPurge() {
    this.hiveSectionService.deleteHiveSection(this.hiveSection.id).subscribe(c => this.navigateToSections());
  }
}
