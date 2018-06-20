import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { User } from '../models/user';
import { CartService } from '../services/cart.service';
import { CategoryService } from '../services/category.service';
import { StoreService } from '../services/store.service';
import { ProductService } from '../services/product.service';
import { ShippingAddressService } from '../services/shipping-address.service';
import { ProductCartService } from '../services/product-cart.service';
import { Cart } from '../models/cart';
import { Category } from '../models/category';
import { Store } from '../models/store';
import { Product } from '../models/product';
import { ShippingAddress } from '../models/shipping-address';
import { ProductCart } from '../models/product-cart';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {

  us : User;
  car : Cart;
  cat : Category;
  sto : Store;
  pro : Product;
  sad : ShippingAddress;
  poc : ProductCart;

  constructor(private userService : UserService, private cartService : CartService, 
    private categoryService : CategoryService, private storeService : StoreService,
    private productService : ProductService, private shippingAddressService : ShippingAddressService,
    private productCartService : ProductCartService) { }

  ngOnInit() {
    this.userService.getById('1').subscribe(response => { this.us = response; }, error => { });
    this.cartService.getById('1').subscribe(response => { this.car = response; }, error => { });
    this.categoryService.getById('1').subscribe(response => { this.cat = response; }, error => { });
    this.storeService.getById('1').subscribe(response => { this.sto = response; }, error => { });
    this.productService.getById('1').subscribe(response => { this.pro = response; }, error => { });
    this.shippingAddressService.getById('1').subscribe(response => { this.sad = response; }, error => { });
    this.productCartService.getById('1').subscribe(response => { this.poc = response; }, error => { });
  }

}
