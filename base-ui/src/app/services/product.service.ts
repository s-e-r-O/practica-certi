import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Product } from '../models/product';
import { Category } from '../models/category';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  
  constructor(private http: HttpClient){}

  public getAll() : Observable<Product[]> {
    return this.http.get<Partial<Product>[]>('/api/products').pipe(
      map((products: Partial<Product>[]) => products.map(product => new Product(product)) )
    );
  }
  
  public getById(code : string) : Observable<Product> {
    return this.http.get<Partial<Product>>('/api/products/' + code).pipe(map((product: Partial<Product>) => new Product(product)));
  }

  public create(product : Product) : Observable<{ code : string }> {
    return this.http.post('/api/products', product) as Observable<{ code : string }>;
  }
  
  public update(product : Product) : Observable<{ code : string }> {
    return this.http.put('/api/products', product) as Observable<{ code : string }>;
  }

  public delete(code : string) : Observable<{ code : string }> {
    return this.http.delete('/api/products/' + code) as Observable<{ code : string }>;
  }


}
