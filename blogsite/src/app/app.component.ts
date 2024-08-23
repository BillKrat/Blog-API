import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  title = 'blogsite';

  constructor(private http: HttpClient){

  }

  ngOnInit(): void {
    
  }

  public onSave() {
    this.http.get('https://localhost:5175/WeatherForecast').subscribe(config=>{
      console.log(config);
    });

  }
}
