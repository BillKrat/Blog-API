import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';

import { AppModule } from './app.module';
import { AppComponent } from './app.component';
import { AuthService, AuthConfigService } from '@auth0/auth0-angular';

@NgModule({
  imports: [
    AppModule,
    ServerModule,
  ],
  // https://stackoverflow.com/questions/75291104/how-can-auth0-be-configured-to-work-with-angular-universal-ssr-starting-from-the
  // https://github.com/auth0/auth0-angular/issues/432
  providers: [
    {
      provide: AuthService,
      useValue: {},
    },
    { provide: AuthConfigService, 
      useValue: {} as any 
    },
  ],
  bootstrap: [AppComponent],
})
export class AppServerModule {}
