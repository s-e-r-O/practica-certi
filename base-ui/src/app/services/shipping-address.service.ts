import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { ShippingAddress } from '../models/shipping-address';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class ShippingAddressService {

  constructor(private http: HttpClient, private userService : UserService){}

  public getAll() : Observable<ShippingAddress[]> {
    return this.http.get<Partial<ShippingAddress>[]>('http://localhost:6064/api/shippingaddress/' + this.userService.currentUser()).pipe(
      map((shippingAddresses: Partial<ShippingAddress>[]) => shippingAddresses.map(shippingAddress => new ShippingAddress(shippingAddress)) )
    );
  }
  
  public getById(name : string) : Observable<ShippingAddress> {
    return this.http.get<Partial<ShippingAddress>>('http://localhost:6064/api/shippingaddress/' + name).pipe(map((shippingAddress: Partial<ShippingAddress>) => new ShippingAddress(shippingAddress)));
  }

  public create(shippingAddress : ShippingAddress) : Observable<{ identifier : string }> {
    return this.http.post('http://localhost:6064/api/shippingaddress', shippingAddress) as Observable<{ identifier : string }>;
  }
  
  public update(shippingAddress : ShippingAddress) : Observable<{ identifier : string }> {
    return this.http.put('http://localhost:6064/api/shippingaddress', shippingAddress) as Observable<{ identifier : string }>;
  }

  public delete(identifier : string) : Observable<{ identifier : string }> {
    return this.http.delete('http://localhost:6064/api/shippingaddress/' + identifier) as Observable<{ identifier : string }>;
  }

}
