import { Component, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { securityService } from './services/security.service';
@Component({
  imports:[CommonModule],
  selector: 'app-auth-button',
  template: `
    <ng-container *ngIf="auth.isAuthenticated$ | async; else loggedOut">
      <button (click)="auth.logout({ logoutParams: { returnTo: 'https://localhost:4200' } })">
        Log out
      </button>
    </ng-container>

    <ng-template #loggedOut>
      <button (click)="auth.loginWithRedirect()">Log in</button>
    </ng-template>
  `,
  standalone: true
})
export class AuthButtonComponent {
  constructor(public auth: securityService) {}
}