import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestComponent } from './test/test.component';
import { MainComponent } from './main/main.component';
import { CartComponent } from './cart/cart.component';

const routes: Routes = [
  { path: 'test', component: TestComponent },
  { path: '', component: MainComponent, 
    children:[
      { path: 'cart', component: CartComponent }
    ] 
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
