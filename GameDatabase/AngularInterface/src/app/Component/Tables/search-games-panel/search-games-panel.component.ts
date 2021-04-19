import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";
import { Game, Search } from "../../../Models/Game";
import { GamesServiceService } from "../../Games/services/games-service.service";
import { CommonServiceService } from "../../Services/common-service.service";


@Component({
  selector: 'app-search-games-panel',
  templateUrl: './search-games-panel.component.html',
  styleUrls: ['./search-games-panel.component.css']
})
export class SearchGamesPanelComponent implements OnInit {
  searchObject: Search;
  searchGamesForm: FormGroup;
  @Input() data: Game[];
  @Output() dataChange: EventEmitter<Game[]> = new EventEmitter<Game[]>()
  @Input() isFavourites: boolean;

  constructor(private formBuilder: FormBuilder, public gamesService: GamesServiceService, public commonService: CommonServiceService) { }

  ngOnInit() {
    this.searchObject = new Search();
    this.searchGamesForm = this.formBuilder.group({
      name: []
    });
    this.searchGamesForm.patchValue(this.searchObject);
  }

  submit() {
    if (!this.searchGamesForm.valid) {
      return;
    }

    this.gamesService.search(this.searchGamesForm.getRawValue()).subscribe(result => {
      debugger;
      this.data = result;
      this.dataChange.emit(this.data);
    })
  }
}
