import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Store } from '../models/store';

@Injectable({
  providedIn: 'root'
})
export class StoreService {

  public getAll() : Observable<Store[]> {
    return of([
      new Store({ name: 'La Casa', line1: 'AAA', line2: 'BBB', phone: 1234}),
      new Store({ name: 'La Casa 2', line1: 'AAA', line2: 'BBB', phone: 1234})
    ]);
  }
  
  public getById(name : string) : Observable<Store> {
    return of(new Store({ name: name, line1: 'AAA', line2: 'BBB', phone: 1234}));
  }

  public create(store : Store) : Observable<{ name : string }> {
    return of({ name: 'Aaa' });
  }
  
  public update(store : Store) : Observable<{ name : string }> {
    return of({ name: 'Aaa' });
  }

  public delete(store : Store) : Observable<{ name : string }> {
    return of({ name: 'Aaa' });
  }

}
