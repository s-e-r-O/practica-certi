import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestComponent } from './test/test.component';
import { ShippingComponent } from './shipping/shipping.component';
import { StoreComponent } from './store/store.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { LoginComponent } from './login/login.component';
import { MainComponent } from './main/main.component';
import { CartComponent } from './cart/cart.component';

const routes: Routes = [
  { path: '', component: MainComponent, 
  children:[
    { path: 'store', component: StoreComponent},
    { path: 'product',component: ProductDetailsComponent},
    { path: 'cart', component: CartComponent },
    { path: 'shipping', component: ShippingComponent },
  ] 
  },
  { path: 'login', component: LoginComponent },
  { path: 'test', component: TestComponent },
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
