import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class TicketService {
  private apiURL: string = 'http://backend/';
  private http = inject(HttpClient);

  saveTicket(title: string, description: string): Observable<any> {
    const data = { title, description };
    console.log(title, description);
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
    });

    return this.http.post(`${this.apiURL}Tickets`, data, { headers });
  }
}
