import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Developer } from '../../../Models/Developer';
import { AddDeveloperPopUpComponent } from '../../PopUps/add-developer-pop-up/add-developer-pop-up.component';
import { CommonServiceService } from '../../Services/common-service.service';
import { DevelopersListTableComponent } from '../../Tables/developers-list-table/developers-list-table.component';
import { DevelopersServiceService } from '../services/developers-service.service';

@Component({
  selector: 'app-developer-list',
  templateUrl: './developer-list.component.html',
  styleUrls: ['./developer-list.component.css']
})
export class DeveloperListComponent implements OnInit {

  @ViewChild("developersTable") developersTable: DevelopersListTableComponent;

  constructor(public dialog: MatDialog, private developerService: DevelopersServiceService, private commonService: CommonServiceService) { }

  ngOnInit() {
  }

  openDialog(): void {
    debugger;
    const dialogRef = this.dialog.open(AddDeveloperPopUpComponent, {
      width: '350px',
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.developerService.add(result).subscribe(result => {
          debugger;
          let targetObject: Developer = new Developer();
          Object.assign(targetObject, result);
          this.developersTable.data.push(targetObject);
          this.developersTable.changeDataSource();
        }, error => {
          debugger;
          this.commonService.handleError(error.error, error.status);
        });
      }
    });
  }

}
