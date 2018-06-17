import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { ProductCart } from '../models/product-cart';
import { Store } from '../models/store';

@Injectable({
  providedIn: 'root'
})
export class ProductCartService {

  public getAll() : Observable<ProductCart[]> {
    return of([
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
    ]);
  }
  
  public getById(productCode : string) : Observable<ProductCart> {
    return of(new ProductCart({
        productCode: "AAA", 
        selectedDelivery: "On-Store",
        quantity: 3,
        store: new Store({name: "123", line1:"AAA", line2:"BBB", phone: 1234})
      }));
  }

  public create(ProductCart : ProductCart) : Observable<{ productCode : string }> {
    return of({ productCode: "Aaa" });
  }
  
  public update(ProductCart : ProductCart) : Observable<{ productCode : string }> {
    return of({ productCode: "Aaa" });
  }

  public delete(ProductCart : ProductCart) : Observable<{ productCode : string }> {
    return of({ productCode: "Aaa" });
  }

}
