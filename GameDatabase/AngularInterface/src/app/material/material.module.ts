import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule, MatPaginatorModule, MatSortModule, MatProgressSpinnerModule, MatMenuModule, MatIconModule, MatDialogModule, MatFormFieldModule, MatInputModule, MatButtonModule } from '@angular/material';
@NgModule({
    declarations: [
    ],
    imports: [
        CommonModule,
        MatTableModule,
        MatPaginatorModule,
        MatSortModule,
        MatProgressSpinnerModule,
        MatMenuModule,
        MatIconModule,
        MatDialogModule,
        MatFormFieldModule,
        MatInputModule,
        MatButtonModule
    ],
    exports: [
        MatTableModule,
        MatPaginatorModule,
        MatSortModule,
        MatProgressSpinnerModule,
        MatMenuModule,
        MatIconModule,
        MatDialogModule
    ]
})
export class MaterialModule { }
