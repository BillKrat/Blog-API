import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  imports:[CommonModule],
  selector: 'app-user-profile',
  template: `
    <ul *ngIf="auth.user$ | async as user">
      <b>Auth0 payload:</b><i>{{ user | json }}</i>
    </ul>
    `,
  standalone: true
})
export class UserProfileComponent {
  constructor(public auth: AuthService) {}
}