import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { provideAuth0 } from '@auth0/auth0-angular';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ButtonModule } from 'primeng/button';
import { AuthButtonComponent } from './AuthButtonComponent';
import { environment as env } from '../environments/environment';

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
    provideAuth0({...env.auth})
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
