import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GamesModule } from './Component/Games/games.module';
import { PublishersModule } from './Component/Publishers/publishers.module';
import { DevelopersModule } from './Component/Developers/developers.module';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';
import { HttpClientModule } from '@angular/common/http';
import { MaterialModule } from './Material/material.module';
import { PopUpsModule } from './Component/PopUps/pop-ups/pop-ups.module';
import { AddGamePopUpComponent } from './Component/PopUps/add-game-pop-up/add-game-pop-up.component';
import { SearchDevelopersPopUpComponent } from './Component/PopUps/search-developers-pop-up/search-developers-pop-up.component';
import { SearchPublishersPopUpComponent } from './Component/PopUps/search-publishers-pop-up/search-publishers-pop-up.component';
import { ButtonsModule } from './Component/Buttons/buttons.module';
import { UsersModule } from './Component/Users/users.module';
import { LandingPageComponent } from './Component/landing-page/landing-page.component';
import { AddPublisherPopUpComponent } from './Component/PopUps/add-publisher-pop-up/add-publisher-pop-up.component';
import { AddDeveloperPopUpComponent } from './Component/PopUps/add-developer-pop-up/add-developer-pop-up.component';
import { ErrorPopUpComponent } from './Component/PopUps/error-pop-up/error-pop-up.component';
import { SharedModule } from './Component/Shared/shared.module';
import { ConfirmationDialogComponent } from './Component/Shared/confirmation-dialog/confirmation-dialog.component';
import { GameDefinitionlisComponent } from './Component/Games/game-definition/game-definitionlis.component';
import { CanActivatePath } from './Component/Services/can-activate.service';
import { NgModule } from '@angular/core';

@NgModule({
  declarations: [
    AppComponent,
    LandingPageComponent
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
    ErrorPopUpComponent,
    GameDefinitionlisComponent
  ],
  providers: [CanActivatePath],
  bootstrap: [AppComponent]
})
export class AppModule { }
