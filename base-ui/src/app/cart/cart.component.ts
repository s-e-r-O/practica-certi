import { Component, OnInit } from '@angular/core';
import { ProductCart } from '../models/product-cart';
import { ProductCartService } from '../services/product-cart.service';
import { CartService } from '../services/cart.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  private products : ProductCart[];
  private productsCount : number;
  private totalPrice : number;
  constructor(private cartService : CartService, private userService : UserService) { 
    this.cartService.getById(this.userService.currentUser()).subscribe(
      response => { 
        this.products = response.productCarts; 
        this.productsCount = this.products.length;
      }
    );
    this.totalPrice = 0;
  }

  ngOnInit() {
  }
  addPrice($event){
    this.totalPrice += $event;
  }
}
