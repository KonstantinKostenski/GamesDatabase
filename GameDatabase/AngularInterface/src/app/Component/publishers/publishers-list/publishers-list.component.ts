import { Component, OnInit } from '@angular/core';
import { PublishersServiceService } from '../services/publishers-service.service';

@Component({
  selector: 'app-publishers-list',
  templateUrl: './publishers-list.component.html',
  styleUrls: ['./publishers-list.component.css']
})
export class PublishersListComponent implements OnInit {
  pageNumber: number = 1;

  constructor(private publisherService: PublishersServiceService) { }

  ngOnInit() {
  }

  loadPreviousPage() {
    if (this.pageNumber > 1) {
      this.pageNumber--;
    }


  }

  loadNextPage() {
    this.pageNumber++;
  }

}
