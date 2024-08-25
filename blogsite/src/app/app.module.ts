import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthButtonComponent } from './components/security/auth.button.component';
import { CommonModule } from '@angular/common';
import { environment as env } from '../environments/environment.dev';
import { UserProfileComponent } from './components/user/app.user.profile';
import { provideAuth0 } from '@auth0/auth0-angular';
import { inject, NgModule } from '@angular/core';
import { HttpEvent, HttpHandlerFn, HttpRequest, provideHttpClient, withInterceptors } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { securityService } from './services/security.service';

export function authInterceptor(
  req: HttpRequest<unknown>,
  next: HttpHandlerFn): Observable<HttpEvent<unknown>> {
    var token = inject(securityService).getToken();
    const newReq = req.clone({
      headers: req.headers.append('Authorization', `Bearer ${token}` ),
    });
  return next(newReq);
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
    securityService,
    provideAuth0({...env.auth}),
    provideHttpClient(withInterceptors([authInterceptor]))
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
 
