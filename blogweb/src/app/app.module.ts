import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { provideAuth0 } from '@auth0/auth0-angular';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthService, AuthConfigService } from '@auth0/auth0-angular';
import { ButtonModule } from 'primeng/button';
import { AuthButtonComponent } from './AuthButtonComponent';


@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    ButtonModule,
    AuthButtonComponent
  ],
  providers: [
    provideClientHydration(),
    provideAuth0({
      domain: 'dev-a0hjb1v0jos2opg2.us.auth0.com',
      clientId: 'vccpAHztTEWWkYWqiJ19SE02jtJUGrdT',
      authorizationParams: {
        redirect_uri: "https://localhost:4200"
      }
    })
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
