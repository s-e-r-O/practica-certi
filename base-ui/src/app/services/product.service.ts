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
        price: "$4.99",
        imageURL: "https://images-na.ssl-images-amazon.com/images/I/514GfnjbUCL._SX355_.jpg",
        category: new Category({ name: "Category", description: "BBB"})
      }),
      new Product({
        code: "456", 
        name: "Product2", 
        description: "AAAA",
        type: "Digital",
        delivery: "None",
        price: "$4.99",
        imageURL: "https://store.storeimages.cdn-apple.com/4666/as-images.apple.com/is/image/AppleInc/aos/published/images/i/ph/iphone/x/iphone-x-silver-select-2017?wid=305&hei=358&fmt=jpeg&qlt=95&op_usm=0.5,0.5&.v=1515602510472",
        category: new Category({ name: "Category", description: "BBB"})
      }),
      new Product({
        code: "123", 
        name: "Product1", 
        description: "AAAA",
        type: "Digital",
        delivery: "None",
        price: "$4.99",
        imageURL: "https://images-na.ssl-images-amazon.com/images/I/514GfnjbUCL._SX355_.jpg",
        category: new Category({ name: "Category", description: "BBB"})
      }),
      new Product({
        code: "456", 
        name: "Product2", 
        description: "AAAA",
        type: "Digital",
        delivery: "None",
        price: "$4.99",
        imageURL: "https://store.storeimages.cdn-apple.com/4666/as-images.apple.com/is/image/AppleInc/aos/published/images/i/ph/iphone/x/iphone-x-silver-select-2017?wid=305&hei=358&fmt=jpeg&qlt=95&op_usm=0.5,0.5&.v=1515602510472",
        category: new Category({ name: "Category", description: "BBB"})
      }),
      new Product({
        code: "123", 
        name: "Product1", 
        description: "AAAA",
        type: "Digital",
        delivery: "None",
        price: "$4.99",
        imageURL: "https://images-na.ssl-images-amazon.com/images/I/514GfnjbUCL._SX355_.jpg",
        category: new Category({ name: "Category", description: "BBB"})
      }),
      new Product({
        code: "456", 
        name: "Product2", 
        description: "AAAA",
        type: "Digital",
        delivery: "None",
        price: "$4.99",
        imageURL: "https://store.storeimages.cdn-apple.com/4666/as-images.apple.com/is/image/AppleInc/aos/published/images/i/ph/iphone/x/iphone-x-silver-select-2017?wid=305&hei=358&fmt=jpeg&qlt=95&op_usm=0.5,0.5&.v=1515602510472",
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
      imageURL: "https://images-na.ssl-images-amazon.com/images/I/514GfnjbUCL._SX355_.jpg",
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
