import { AfterViewInit, ChangeDetectorRef, Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
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
  @Input() data: GamesListItem[];
  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['Id', 'Name'];

  constructor(private gamesService: GamesServiceService, private cd: ChangeDetectorRef) {

  }
    ngOnInit(): void {
      debugger;
    }

  ngAfterViewInit() {
    this.dataSource = new GamesListDataSource(this.paginator, this.sort, this.data);
    this.cd.detectChanges();
  }
}
