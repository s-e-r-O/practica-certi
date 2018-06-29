import { Injectable } from '@angular/core';

import { Observable, Subject } from 'rxjs';
import { Cart } from '../models/cart';
import { ProductCart } from '../models/product-cart';
import { Store } from '../models/store';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  
  private addedProductToCartSource = new Subject<void>();
    
  addedProduct$ = this.addedProductToCartSource.asObservable();

  constructor(private http: HttpClient, private userService : UserService){}

  public getAll() : Observable<Cart[]> {
    return this.http.get<Partial<Cart>[]>('http://localhost:6064/api/cart').pipe(
      map((carts: Partial<Cart>[]) => carts.map(cart => new Cart(cart)) )
    );
  }
  
  public getById(username : string) : Observable<Cart> {
    return this.http.get<Partial<Cart>>('http://localhost:6064/api/cart/' + username).pipe(map((cart: Partial<Cart>) => new Cart(cart)));
  }

  public create(cart : Cart) : Observable<{ id : string }> {
    return this.http.post('http://localhost:6064/api/cart', cart) as Observable<{ id : string }>;
  }
  
  public update(cart : Cart) : Observable<{ username : string }> {
    return this.http.put('http://localhost:6064/api/cart', cart) as Observable<{ username : string }>;
  }

  public delete() : Observable<{ username : string }> {
    return this.http.delete('http://localhost:6064/api/cart/' + this.userService.currentUser()) as Observable<{ username : string }>;
  }

  public updateProductNumbers(){
    this.addedProductToCartSource.next();
  }
}
