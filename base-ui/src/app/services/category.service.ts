import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Category } from '../models/category';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  
  constructor(private http: HttpClient){}

  public getAll() : Observable<Category[]> {
    return this.http.get<Partial<Category>[]>('http://localhost:6064/api/category').pipe(
      map((categories: Partial<Category>[]) => categories.map(category => new Category(category)) )
    );
  }
  
  public getById(name : string) : Observable<Category> {
    return this.http.get<Partial<Category>>('http://localhost:6064/api/category/' + name).pipe(map((category: Partial<Category>) => new Category(category)));
  }

  public create(category : Category) : Observable<{ name : string }> {
    return this.http.post('http://localhost:6064/api/category', category) as Observable<{ name : string }>;
  }
  
  public update(category : Category) : Observable<{ name : string }> {
    return this.http.put('http://localhost:6064/api/category', category) as Observable<{ name : string }>;
  }

  public delete(name : string) : Observable<{ name : string }> {
    return this.http.delete('http://localhost:6064/api/category/' + name) as Observable<{ name : string }>;
  }


}
