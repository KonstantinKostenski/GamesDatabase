import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator'
import { FavouritesListDataSource } from './favourites-list-table-datasource';

@Component({
  selector: 'app-favourites-list-table',
  templateUrl: './favourites-list-table.component.html',
  styleUrls: ['./favourites-list-table.component.css']
})
export class FavouritesListTableComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator: MatPaginator | undefined;
  @ViewChild(MatSort) sort: MatSort | undefined;
  dataSource: FavouritesListDataSource | undefined;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['id', 'name'];

  ngAfterViewInit() {
    this.dataSource = new FavouritesListDataSource(this.paginator, this.sort);
  }
}
