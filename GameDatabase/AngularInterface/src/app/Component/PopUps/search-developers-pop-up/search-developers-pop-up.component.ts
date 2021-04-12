import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Developer, DeveloperSearch } from '../../../Models/Developer';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { DevelopersServiceService } from '../../Developers/services/developers-service.service';
import { AddDeveloperPopUpComponent } from '../add-developer-pop-up/add-developer-pop-up.component';

@Component({
  selector: 'app-search-developers-pop-up',
  templateUrl: './search-developers-pop-up.component.html',
  styleUrls: ['./search-developers-pop-up.component.css']
})
export class SearchDevelopersPopUpComponent implements OnInit {
  searchDeveloperForm: FormGroup;
  searchObject: DeveloperSearch;
  data: Developer[];
  selectedDeveloper: Developer;
  shouldShowGrid: boolean;
  constructor(private formBuilder: FormBuilder, public dialogRef: MatDialogRef<SearchDevelopersPopUpComponent>, private developersService: DevelopersServiceService, public dialog: MatDialog) { }

  ngOnInit() {
    this.searchObject = new DeveloperSearch();
    this.searchDeveloperForm = this.formBuilder.group({
      name: [null, Validators.required]
    });
    this.searchDeveloperForm.patchValue(this.searchObject);
  }

  submit() {
    debugger;
    if (!this.searchDeveloperForm.valid) {
      return;
    }
    this.shouldShowGrid = true;
    this.developersService.search(this.searchDeveloperForm.getRawValue()).subscribe(result => {
      debugger;
      this.data = result;
      //this.dialogRef.close(result);

    })

  }

  addNewDeveloper() {
    const dialogRef = this.dialog.open(AddDeveloperPopUpComponent, {
      width: '350px',
    });
    dialogRef.afterClosed().subscribe(result => {
      debugger;
      if (result) {
        this.developersService.add(result).subscribe(result => {
          debugger;
          this.data = [...this.data, result]
        });
      }
    });
  }

  recieveResult(result) {
    debugger;
    this.selectedDeveloper = result;
  }

  chooseFromGrid() {
    debugger;
    if (this.selectedDeveloper) {
      this.data = null;
      this.shouldShowGrid = false;
      this.dialogRef.close(this.selectedDeveloper);
    }
  }
}
