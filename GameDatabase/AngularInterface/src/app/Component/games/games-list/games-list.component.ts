import { Component, OnInit } from '@angular/core';
import { GamesListItem } from '../../Tables/games-list/games-list-datasource';
import { GamesServiceService } from '../services/games-service.service';

@Component({
  selector: 'app-games-list',
  templateUrl: './games-list.component.html',
  styleUrls: ['./games-list.component.css']
})
export class GamesListComponent implements OnInit {
  data: GamesListItem[];

  constructor(private gamesService: GamesServiceService) { }

  ngOnInit() {
    this.gamesService.getAllGames().subscribe(result => {
      debugger;
      this.data = result;
    });
  }

}
