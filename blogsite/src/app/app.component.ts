import { CommonModule } from '@angular/common';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { catchError, throwError } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  public title = 'blogsite';
  public errorMessage:any;
  public successMessage:any;

  constructor(private http: HttpClient){

  }

  ngOnInit(): void {
    
  }
  
  public onSave() {
    var result = this.http.get('https://localhost:5175/WeatherForecast')
      .subscribe({
        next: response => {
          this.successMessage = response;
        },
        error: err => {
          console.log('EXCEPTION',err);
          this.errorMessage = err;
          // We can show an error message to the user or retry the request.
        }
      });
  }

}
