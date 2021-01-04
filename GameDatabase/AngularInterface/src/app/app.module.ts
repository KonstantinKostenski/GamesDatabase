import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GamesModule } from './Component/games/games.module';
import { PublishersModule } from './Component/publishers/publishers.module';
import { DevelopersModule } from './Component/developers/developers.module';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';
import { HttpClientModule } from '@angular/common/http';
import { MaterialModule } from './material/material.module';
import { ConfirmationDialogComponent } from './components/shared/confirmation-dialog/confirmation-dialog.component';
import { SharedModule } from './components/shared/shared.module';
import { PopUpsModule } from './Component/PopUps/pop-ups/pop-ups.module';

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        GamesModule,
        HttpClientModule,
        PublishersModule,
        DevelopersModule,
        BsDropdownModule.forRoot(),
        TooltipModule.forRoot(),
        ModalModule.forRoot(),
        MaterialModule,
        SharedModule,
        PopUpsModule
    ],
    entryComponents: [
        ConfirmationDialogComponent
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
