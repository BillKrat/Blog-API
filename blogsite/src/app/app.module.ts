import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthButtonComponent } from './auth.button.component';
import { CommonModule } from '@angular/common';
import { environmentdev as envdev } from '../environments/environment.dev';
import { UserProfileComponent } from './app.user.profile';
import { provideAuth0 } from '@auth0/auth0-angular';
import { inject, NgModule } from '@angular/core';
import { HttpEvent, HttpHandlerFn, HttpRequest, provideHttpClient, withInterceptors } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { AuthService } from '@auth0/auth0-angular';

export function authInterceptor(
  req: HttpRequest<unknown>,
  next: HttpHandlerFn): Observable<HttpEvent<unknown>> {
    var state = inject(AuthService).appState$;
    console.log('INTERCEPTOR',req);
  return next(req);
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    AuthButtonComponent,
    UserProfileComponent,
    CommonModule
  ],
  providers: [
    provideAuth0({...envdev.auth}),
    provideHttpClient(withInterceptors([authInterceptor]))
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
 
