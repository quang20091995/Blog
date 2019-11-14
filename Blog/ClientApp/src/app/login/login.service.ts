import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoginModelView } from '../modelview/LoginModelView';
import { map, filter, scan } from 'rxjs/operators';

@Injectable({
    providedIn: 'root',
})
export class LoginService {
    baseUrl = 'https://localhost:44393/api/user/Login';

    constructor(private http: HttpClient) { }

    //Login Method
    login(username: string, password: string) {
        // pipe() let you combine multiple functions into a single function. 
        // pipe() runs the composed functions in sequence.
        return this.http.post<any>(this.baseUrl, { username, password }).pipe(
            map(result => {
                // login successful if there's a jwt token in the response
                if (result && result.token) {
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('jwt', result.token);
                    localStorage.setItem('username', result.username);
                    localStorage.setItem('expiration', result.expiration);
                    localStorage.setItem('userRole', result.userRole);
                }
                return result;
            })

        );
    }
}
