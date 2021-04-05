import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-favourites-list',
  templateUrl: './favourites-list.component.html',
  styleUrls: ['./favourites-list.component.css']
})
export class FavouritesListComponent implements OnInit {
  isFavourites: boolean = true;

  constructor() { }

  ngOnInit() {
  }

}
