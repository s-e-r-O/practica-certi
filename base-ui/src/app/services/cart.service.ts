import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Cart } from '../models/cart';
import { ProductCart } from '../models/product-cart';
import { Store } from '../models/store';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  public getAll() : Observable<Cart[]> {
    return of([
      new Cart({
        username: "user1",
        productCarts: [
          new ProductCart({
            productCode: "AAA", 
            selectedDelivery: "On-Store",
            quantity: 4,
            store: new Store({name: "123", line1:"AAA", line2:"BBB", phone: 1234})
          })
        ]
      }),
      new Cart({
        username: "user2",
        productCarts: [
          new ProductCart({
            productCode: "BBB", 
            selectedDelivery: "On-Store",
            quantity: 4,
            store: new Store({name: "123", line1:"AAA", line2:"BBB", phone: 1234})
          }),
          new ProductCart({
            productCode: "AAA", 
            selectedDelivery: "On-Store",
            quantity: 3,
            store: new Store({name: "123", line1:"AAA", line2:"BBB", phone: 1234})
          })
        ]
      })
    ]);
  }
  
  public getById(username : string) : Observable<Cart> {
    return of(new Cart({
      productCarts: [
        new ProductCart({
          productCode: "AAA", 
          selectedDelivery: "On-Store",
          quantity: 4,
          store: new Store({name: "123", line1:"AAA", line2:"BBB", phone: 1234})
        }),
        new ProductCart({
          productCode: "BBB", 
          selectedDelivery: "On-Store",
          quantity: 6,
          store: new Store({name: "123", line1:"AAA", line2:"BBB", phone: 1234})
        })
      ],
      username: username
    }));
  }

  public create(cart : Cart) : Observable<{ username : string }> {
    return of({ username: "Aaa" });
  }
  
  public update(cart : Cart) : Observable<{ username : string }> {
    return of({ username: "Aaa" });
  }

  public delete(cart : Cart) : Observable<{ username : string }> {
    return of({ username: "Aaa" });
  }

}
