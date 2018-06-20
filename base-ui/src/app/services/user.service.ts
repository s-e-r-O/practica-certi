import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { User } from '../models/user';
import { ShippingAddress } from '../models/shipping-address';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private cookieService : CookieService){}

  public getAll() : Observable<User[]> {
    return of([
      new User( { 
        username: "user1", 
        name: "Mauricio", 
        lastName: "Terceros", 
        password: "1234", 
        shipAdress: [
          new ShippingAddress({identifier: "123", line1: "AAA", line2: "BBB"}),
          new ShippingAddress({identifier: "123", line1: "AAA", line2: "BBB"})
        ] 
      }),
      new User( { 
        username: "user2", 
        name: "Mauricio", 
        lastName: "Terceros", 
        password: "1234", 
        shipAdress: [
          new ShippingAddress({identifier: "123", line1: "AAA", line2: "BBB"}),
          new ShippingAddress({identifier: "123", line1: "AAA", line2: "BBB"})
        ] 
      })
    ]);
  }
  
  public getById(username : string) : Observable<User> {
    return of(new User( { 
      username: username, 
      name: "Mauricio", 
      lastName: "Terceros", 
      password: "1234", 
      shipAdress: [
        new ShippingAddress({identifier: "123", line1: "AAA", line2: "BBB"}),
        new ShippingAddress({identifier: "123", line1: "AAA", line2: "BBB"})
      ] 
    }));
  }

  public create(user : User) : Observable<{ username : string }> {
    return of({ username: "Aaa" });
  }
  
  public update(user : User) : Observable<{ username : string }> {
    return of({ username: "Aaa" });
  }

  public delete(user : User) : Observable<{ username : string }> {
    return of({ username: "Aaa" });
  }

  public currentUser() : string {
    return this.cookieService.get('Username');
  }

  public isLoggedIn() : boolean {
    return this.cookieService.check('Username');
  }
}
