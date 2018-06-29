import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';


import { AppComponent } from './app.component';
import { AppRoutingModule } from './/app-routing.module';
import { TestComponent } from './test/test.component';
import { ShippingAddressFormComponent } from './shipping-address-form/shipping-address-form.component';
import { ShippingAddressViewComponent } from './shipping-address-view/shipping-address-view.component';
import { ShippingComponent } from './shipping/shipping.component';
import { ProductComponent } from './product/product.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { StoreComponent } from './store/store.component';
import { LoginComponent } from './login/login.component';
import { CookieService } from 'ngx-cookie-service';
import { MainComponent } from './main/main.component';
import { NavbarComponent } from './navbar/navbar.component';
import { CartComponent } from './cart/cart.component';
import { ProductCartComponent } from './product-cart/product-cart.component';
import { HttpClientModule } from '@angular/common/http';
import { SignupComponent } from './signup/signup.component';

@NgModule({
  declarations: [
    AppComponent,
    TestComponent,
    ShippingAddressFormComponent,
    ShippingAddressViewComponent,
    ShippingComponent,
    ProductComponent,
    ProductDetailsComponent,
    StoreComponent,
    LoginComponent,
    MainComponent,
    NavbarComponent,
    CartComponent,
    ProductCartComponent,
    SignupComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule.forRoot(),
    FormsModule,
    ReactiveFormsModule, 
    HttpClientModule
  ],
  providers: [CookieService],
  bootstrap: [AppComponent]
})
export class AppModule { }
