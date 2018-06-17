import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { User } from '../models/user';
import { ShippingAddress } from '../models/shipping-address';

@Injectable({
  providedIn: 'root'
})
export class UserService {

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

}
