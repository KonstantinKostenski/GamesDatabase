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
import { PopUpsModule } from './Component/PopUps/pop-ups/pop-ups.module';
import { AddGamePopUpComponent } from './Component/PopUps/add-game-pop-up/add-game-pop-up.component';
import { SearchDevelopersPopUpComponent } from './Component/PopUps/search-developers-pop-up/search-developers-pop-up.component';
import { SearchPublishersPopUpComponent } from './Component/PopUps/search-publishers-pop-up/search-publishers-pop-up.component';
import { ButtonsModule } from './Component/Buttons/buttons.module';
import { UsersModule } from './Component/users/users.module';
import { LandingPageComponent } from './Component/landing-page/landing-page.component';
import { AddPublisherPopUpComponent } from './Component/PopUps/add-publisher-pop-up/add-publisher-pop-up.component';
import { AddDeveloperPopUpComponent } from './Component/PopUps/add-developer-pop-up/add-developer-pop-up.component';
import { ErrorPopUpComponent } from './Component/PopUps/error-pop-up/error-pop-up.component';
import { SharedModule } from './Component/Shared/shared.module';
import { ConfirmationDialogComponent } from './Component/shared/confirmation-dialog/confirmation-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    LandingPageComponent,
    ConfirmationDialogComponent
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
    PopUpsModule,
    ButtonsModule,
    UsersModule
  ],
  entryComponents: [
    ConfirmationDialogComponent,
    AddGamePopUpComponent,
    AddPublisherPopUpComponent,
    AddDeveloperPopUpComponent,
    SearchDevelopersPopUpComponent,
    SearchPublishersPopUpComponent,
    ErrorPopUpComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
