import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../common/UserDetails';

@Injectable({
    providedIn: 'root'
})
export class UserService {
    private apiUrl = 'https://localhost:7285/api/Auth'; // Replace with backend URL

    constructor(private http: HttpClient) {}

    Login(userData:User): Observable<any> {
        return this.http.post<any>(this.apiUrl + '/login' ,userData);

    }
    RegisterUser(userData:User): Observable<any> {
        return this.http.post<any>(this.apiUrl + '/register',userData);
    }

    getUsers(): Observable<any[]> {
        return this.http.get<any[]>(this.apiUrl + '/getUsers');
    }
}