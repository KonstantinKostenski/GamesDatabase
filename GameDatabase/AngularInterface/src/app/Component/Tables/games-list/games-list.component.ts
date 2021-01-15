import { AfterViewInit, ChangeDetectorRef, Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatPaginator, MatSort } from '@angular/material';
import { ConfirmationDialogComponent } from '../../../components/shared/confirmation-dialog/confirmation-dialog.component';
import { GamesServiceService } from '../../games/services/games-service.service';
import { GamesListDataSource, GamesListItem } from './games-list-datasource';

@Component({
  selector: 'app-games-list-table',
  templateUrl: './games-list.component.html',
  styleUrls: ['./games-list.component.css']
})
export class GamesListTableComponent implements AfterViewInit, OnInit{
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: GamesListDataSource;
  data: GamesListItem[];
  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['Id', 'Name', 'Actions'];

  constructor(private gamesService: GamesServiceService, private cd: ChangeDetectorRef, public dialog: MatDialog) {

  }
    ngOnInit(): void {
      debugger;
      this.gamesService.getAllGames(this.paginator.pageIndex, this.paginator.pageSize).subscribe(result => {
        debugger;
        this.data = result;
      });
    }

  ngAfterViewInit() {
    this.dataSource = new GamesListDataSource(this.paginator, this.sort, this.data);
    this.cd.detectChanges();
  }

  getServerData($event) {
    this.gamesService.getAllGames($event.pageIndex, $event.pageSize).subscribe(result => {
      debugger;
      this.data = result;
    });
  }

  openDialog(row): void {
    debugger;
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      width: '350px',
      data: "Do you confirm the deletion of this data?"
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        console.log('Yes clicked');
        // DO SOMETHING
      }
    });
  }
}
