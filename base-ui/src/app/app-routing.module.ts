import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestComponent } from './test/test.component';
import { ShippingComponent } from './shipping/shipping.component';

const routes: Routes = [
  { path: 'test', component: TestComponent },
  { path: 'shipping', component: ShippingComponent },
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
