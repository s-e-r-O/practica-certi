import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Category } from '../models/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  public getAll() : Observable<Category[]> {
    return of([
      new Category({ name: "Category1", description: "AAA"}),
      new Category({ name: "Category2", description: "BBB"})
    ]);
  }
  
  public getById(name : string) : Observable<Category> {
    return of(new Category({ name: name, description: "BBB"}));
  }

  public create(category : Category) : Observable<{ name : string }> {
    return of({ name: "Aaa" });
  }
  
  public update(category : Category) : Observable<{ name : string }> {
    return of({ name: "Aaa" });
  }

  public delete(category : Category) : Observable<{ name : string }> {
    return of({ name: "Aaa" });
  }

}
