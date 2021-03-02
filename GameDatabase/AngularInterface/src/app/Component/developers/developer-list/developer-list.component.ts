import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { AddDeveloperPopUpComponent } from '../../PopUps/add-developer-pop-up/add-developer-pop-up.component';

@Component({
  selector: 'app-developer-list',
  templateUrl: './developer-list.component.html',
  styleUrls: ['./developer-list.component.css']
})
export class DeveloperListComponent implements OnInit {

  constructor(public dialog: MatDialog) { }

  ngOnInit() {
  }

  openDialog(): void {
    debugger;
    const dialogRef = this.dialog.open(AddDeveloperPopUpComponent, {
      width: '350px',
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        //this.publisherService.sa(result);
      }
    });
  }

}
