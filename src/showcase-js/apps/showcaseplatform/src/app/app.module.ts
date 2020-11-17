import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AuthModule } from '@auth0/auth0-angular';
import { SharedUiModule } from '@showcase-js/shared/ui';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    AuthModule.forRoot({
      domain: 'showcaseplatform.eu.auth0.com',
      clientId: 'e2S1T13EV0TniiTOlTrTYSRVjAStSHuJ',
    }),
    SharedUiModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
