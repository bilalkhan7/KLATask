import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  amount: string = '';
  conversionResult: string = '';

  constructor(private http: HttpClient) { }

  convertCurrency() {
    if (!this.amount) {
      alert('Please enter an amount');
      return;
    }
    this.http.post('https://localhost:7241/currencyConverter', { amount: this.amount }, { responseType: 'text' })
      .subscribe(
        (response) => {
          this.conversionResult = response;
        },
        (error) => {
          console.error('Error converting currency:', error);
          this.conversionResult = 'Error converting currency';
        }
      );
  }
}
