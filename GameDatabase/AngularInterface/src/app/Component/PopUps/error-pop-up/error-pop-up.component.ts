import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-error-pop-up',
  templateUrl: './error-pop-up.component.html',
  styleUrls: ['./error-pop-up.component.css']
})
export class ErrorPopUpComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<ErrorPopUpComponent>, public dialog: MatDialog, @Inject(MAT_DIALOG_DATA) public data: any[]) {
    debugger;
  }

  ngOnInit() {
  }

}
