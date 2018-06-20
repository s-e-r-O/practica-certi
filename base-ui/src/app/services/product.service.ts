import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Product } from '../models/product';
import { Category } from '../models/category';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  public getAll() : Observable<Product[]> {
    return of([
      new Product({
        code: "123", 
        name: "Product1", 
        description: "AAAA",
        type: "Digital",
        delivery: "None",
        imageURL: "http://lorempixel.com/200/200",
        category: new Category({ name: "Category", description: "BBB"})
      }),
      new Product({
        code: "456", 
        name: "Product2", 
        description: "AAAA",
        type: "Digital",
        delivery: "None",
        imageURL: "http://lorempixel.com/200/200",
        category: new Category({ name: "Category", description: "BBB"})
      })
    ]);
  }
  
  public getById(code : string) : Observable<Product> {
    return of(new Product({
      code: code, 
      name: "Product", 
      description: "AAAA",
      type: "Digital",
      delivery: "None",
      price: "$4.99",
      imageURL: "http://lorempixel.com/200/200",
      category: new Category({ name: "Category", description: "BBB"})
    }));
  }

  public create(product : Product) : Observable<{ code : string }> {
    return of({ code: "Aaa" });
  }
  
  public update(product : Product) : Observable<{ code : string }> {
    return of({ code: "Aaa" });
  }

  public delete(product : Product) : Observable<{ code : string }> {
    return of({ code: "Aaa" });
  }

}
