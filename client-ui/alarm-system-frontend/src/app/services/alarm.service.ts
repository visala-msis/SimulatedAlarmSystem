import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class AlarmService {
    private apiUrl = 'https://localhost:7285/api/Alarm'; // Replace with backend URL

    constructor(private http: HttpClient) {}

    getAlarms(): Observable<any[]> {
        return this.http.get<any[]>(this.apiUrl);
    }
}
