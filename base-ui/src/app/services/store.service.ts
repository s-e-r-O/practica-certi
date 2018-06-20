import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Store } from '../models/store';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class StoreService {

  constructor(private http: HttpClient){}

  public getAll() : Observable<Store[]> {
    return this.http.get<Partial<Store>[]>('/api/stores').pipe(
      map((stores: Partial<Store>[]) => stores.map(store => new Store(store)) )
    );
  }
  
  public getById(name : string) : Observable<Store> {
    return this.http.get<Partial<Store>>('/api/stores/' + name).pipe(map((store: Partial<Store>) => new Store(store)));
  }

  public create(store : Store) : Observable<{ name : string }> {
    return this.http.post('/api/stores', store) as Observable<{ name : string }>;
  }
  
  public update(store : Store) : Observable<{ name : string }> {
    return this.http.put('/api/stores', store) as Observable<{ name : string }>;
  }

  public delete(name : string) : Observable<{ name : string }> {
    return this.http.delete('/api/Stores/' + name) as Observable<{ name : string }>;
  }

}
