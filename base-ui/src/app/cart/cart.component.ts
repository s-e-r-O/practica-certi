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
  
  private prices : {code: string, price:number}[];
  private totalPrice;

  constructor(private cartService : CartService, private userService : UserService) { 
    this.cartService.getById(this.userService.currentUser()).subscribe(
      response => { 
        console.log(response);
        this.products = response.productCarts; 
        this.productsCount = this.products.length;
      }
    );
    this.prices = [];
    this.totalPrice = 0;
  }

  ngOnInit() {
  }
  addPrice($event){
    console.log($event);
    let ind : number;
    if((ind = this.prices.findIndex(p => p.code === $event.code))>-1){
      this.prices[ind].price = $event.price;
    } else {
      this.prices.push($event);
    }
    this.totalPrice = 0;
    this.prices.forEach(p => this.totalPrice += p.price);
  }
}
