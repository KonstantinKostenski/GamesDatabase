import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatDialog, MatDialogRef } from "@angular/material/dialog";
import { Search } from "../../../Models/Game";
import { Publisher, PublisherSearch } from "../../../Models/Publisher";
import { PublishersServiceService } from "../../Publishers/services/publishers-service.service";
import { AddPublisherPopUpComponent } from "../add-publisher-pop-up/add-publisher-pop-up.component";


@Component({
  selector: 'app-search-publishers-pop-up',
  templateUrl: './search-publishers-pop-up.component.html',
  styleUrls: ['./search-publishers-pop-up.component.css']
})
export class SearchPublishersPopUpComponent implements OnInit {

  searchPublishersForm: FormGroup;
  searchObject: PublisherSearch;
  data: Publisher[];
  selectedPublisher: Publisher;
  shouldShowGrid: boolean;

  constructor(private formBuilder: FormBuilder, public dialogRef: MatDialogRef<SearchPublishersPopUpComponent>, private publisherService: PublishersServiceService, public dialog: MatDialog) { }

  ngOnInit() {
    this.searchObject = new Search();
    this.searchPublishersForm = this.formBuilder.group({
      name: [null, Validators.required]
    });
    this.searchPublishersForm.patchValue(this.searchObject);
  }

  addNewPublisher() {
    const dialogRef = this.dialog.open(AddPublisherPopUpComponent, {
      width: '350px',
    });
    dialogRef.afterClosed().subscribe(result => {
      debugger;
      if (result) {
        this.publisherService.add(result).subscribe(result => {
          debugger;
          this.data = [...this.data, result]
        });
      }
    });
  }

  submit() {
    if (!this.searchPublishersForm.valid) {
      return;
    }

    this.publisherService.search(this.searchPublishersForm.getRawValue()).subscribe(result => {
      debugger;
      this.shouldShowGrid = true;
      this.data = result;
      //this.dialogRef.close(result);

    })

  }

  recieveResult(result) {
    debugger;
    this.selectedPublisher = result;
  }

  chooseFromGrid() {
    debugger;
    if (this.selectedPublisher) {
      this.data = null;
      this.shouldShowGrid = false;
      this.dialogRef.close(this.selectedPublisher);
    }
  }
}
