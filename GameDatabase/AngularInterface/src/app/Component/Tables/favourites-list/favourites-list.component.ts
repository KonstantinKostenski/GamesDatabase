import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { FavouritesListDataSource } from './favourites-list-datasource';
import { MatPaginator } from '@angular/material/paginator'

@Component({
  selector: 'app-favourites-list-table',
  templateUrl: './favourites-list.component.html',
  styleUrls: ['./favourites-list.component.css']
})
export class FavouritesListTableComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: FavouritesListDataSource;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['id', 'name'];

  ngAfterViewInit() {
    this.dataSource = new FavouritesListDataSource(this.paginator, this.sort);
  }
}
