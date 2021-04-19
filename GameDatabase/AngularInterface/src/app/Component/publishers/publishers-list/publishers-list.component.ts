import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddPublisherPopUpComponent } from '../../PopUps/add-publisher-pop-up/add-publisher-pop-up.component';
import { PublishersServiceService } from '../services/publishers-service.service';


@Component({
  selector: 'app-publishers-list',
  templateUrl: './publishers-list.component.html',
  styleUrls: ['./publishers-list.component.css']
})
export class PublishersListComponent implements OnInit {
  pageNumber: number = 1;

  constructor(private publisherService: PublishersServiceService, public dialog: MatDialog) { }

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

  openDialog(): void {
    debugger;
    const dialogRef = this.dialog.open(AddPublisherPopUpComponent, {
      width: '350px',
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        //this.publisherService.sa(result);
      }
    });
  }

}
