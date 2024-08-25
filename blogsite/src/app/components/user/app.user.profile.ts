import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { Observable, Subject } from 'rxjs';

@Component({
  imports:[CommonModule],
  selector: 'app-user-profile',
  template: `
    <ul *ngIf="auth.user$ | async as user">
      <b>Auth0 payload:</b><i>{{id }}</i>
    </ul>
    `,
  standalone: true
})

export class UserProfileComponent {
  public id: string | undefined;

  constructor(public auth: AuthService) {
    auth.user$.subscribe((value:any)=>{
        if(auth.isAuthenticated$ && value?.sub){
          var result =`${value.sub}`.replace('auth0','');
          this.id=result;
          // push id into state service
        }
    })
  }
  getId(): string | undefined{
    return this.id;
  }
}

