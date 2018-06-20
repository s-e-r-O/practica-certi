import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { ProductCart } from '../models/product-cart';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductCartService {

  
  constructor(private http: HttpClient){}

  public getAll() : Observable<ProductCart[]> {
    return this.http.get<Partial<ProductCart>[]>('http://localhost:6064/api/productcart').pipe(
      map((productCarts: Partial<ProductCart>[]) => productCarts.map(productCard => new ProductCart(productCard)) )
    );
  }
  
  public getById(productCode : string) : Observable<ProductCart> {
    return this.http.get<Partial<ProductCart>>('http://localhost:6064/api/productcart/' + productCode).pipe(map((productCard: Partial<ProductCart>) => new ProductCart(productCard)));
  }

  public create(productCard : ProductCart) : Observable<{ productCode : string }> {
    return this.http.post('http://localhost:6064/api/productcart', productCard) as Observable<{ productCode : string }>;
  }
  
  public update(productCard : ProductCart) : Observable<{ productCode : string }> {
    return this.http.put('http://localhost:6064/api/productcart', productCard) as Observable<{ productCode : string }>;
  }

  public delete(productCode : string) : Observable<{ productCode : string }> {
    return this.http.delete('http://localhost:6064/api/productcart/' + productCode) as Observable<{ productCode : string }>;
  }


}
