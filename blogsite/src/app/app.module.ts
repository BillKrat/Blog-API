import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { AuthModule, AuthClientConfig, provideAuth0 } from '@auth0/auth0-angular';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthButtonComponent } from './auth.button.component';
import { CommonModule } from '@angular/common';
import { environment as env } from '../environments/environment';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    AuthButtonComponent,
    CommonModule
  ],
  providers: [
    provideAuth0({...env.auth})
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
