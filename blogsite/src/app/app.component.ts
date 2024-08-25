import { HttpClient} from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { UserProfileComponent } from './components/user/app.user.profile';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers:[UserProfileComponent]
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
        }
      });
  }

}
