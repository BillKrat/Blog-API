// data.service.ts
import { Injectable, OnDestroy } from '@angular/core';
import { AuthService, GetTokenSilentlyOptions, LogoutOptions, RedirectLoginOptions } from '@auth0/auth0-angular';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class securityService implements OnDestroy { 
  public isAuthenticated$: Observable<boolean> | undefined;
  private authToken: string | undefined;

  constructor(public auth: AuthService) 
    {
      // bubble auth isAuthenticated to our security isAuthenticated
      auth.isAuthenticated$.subscribe((value)=>{
        console.log("AUTHENTICATED:", value);
        this.isAuthenticated$ = auth.isAuthenticated$

        auth.getAccessTokenSilently().subscribe((value:string)=>{
            this.authToken = value;
        })
      });
    } 
   
  ngOnDestroy(): void {
  }
  getToken(){
    return this.authToken ?? "not assigned";
  }

  logout(options?: LogoutOptions): Observable<void>{
      return this.auth.logout(options);
  }

  loginWithRedirect(options?: any): Observable<void>{
    return this.auth.loginWithRedirect(options);
  }

  getAccessTokenSilently(options?: GetTokenSilentlyOptions): Observable<string>{
    return this.auth.getAccessTokenSilently(options);
  }

}