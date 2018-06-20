import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../models/user';
import { ShippingAddress } from '../models/shipping-address';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private cookieService : CookieService, private http: HttpClient){}

  public getAll() : Observable<User[]> {
    return this.http.get<Partial<User>[]>('/api/users').pipe(
      map((users: Partial<User>[]) => users.map(user => new User(user)) )
    );
  }
  
  public getById(username : string) : Observable<User> {
    return this.http.get<Partial<User>>('/api/users/' + username).pipe(map((user: Partial<User>) => new User(user)));
  }

  public create(user : User) : Observable<{ username : string }> {
    return this.http.post('/api/users', user) as Observable<{ username : string }>;
  }
  
  public update(user : User) : Observable<{ username : string }> {
    return this.http.put('/api/users', user) as Observable<{ username : string }>;
  }

  public delete(username : string) : Observable<{ username : string }> {
    return this.http.delete('/api/users/' + username) as Observable<{ username : string }>;
  }

  public currentUser() : string {
    return this.cookieService.get('Username');
  }

  public isLoggedIn() : boolean {
    return this.cookieService.check('Username');
  }
}
