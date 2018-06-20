import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { ShippingAddress } from '../models/shipping-address';

@Injectable({
  providedIn: 'root'
})
export class ShippingAddressService {

  public getAll() : Observable<ShippingAddress[]> {
    return of( [
      new ShippingAddress({identifier: "123", line1: "AAA", line2: "BBB", city: "AAA", phone: 123, zone: "DDD"}),
      new ShippingAddress({identifier: "123", line1: "AAA", line2: "BBB", city: "AAA", phone: 12341, zone: "DDD"}),
      new ShippingAddress({identifier: "123", line1: "AAA", line2: "BBB", city: "AAA", phone: 123, zone: "DDD"}),
      new ShippingAddress({identifier: "123", line1: "AAA", line2: "BBB", city: "AAA", phone: 12341, zone: "DDD"}),
    ] );
  }
  
  public getById(identifier : string) : Observable<ShippingAddress> {
    return of(new ShippingAddress({identifier: identifier, line1: "AAA", line2: "BBB"}),);
  }

  public create(shippingAddress : ShippingAddress) : Observable<{ identifier : string }> {
    return of({ identifier: "Aaa" });
  }
  
  public update(shippingAddress : ShippingAddress) : Observable<{ identifier : string }> {
    return of({ identifier: "Aaa" });
  }

  public delete(shippingAddress : ShippingAddress) : Observable<{ identifier : string }> {
    return of({ identifier: "Aaa" });
  }

}
