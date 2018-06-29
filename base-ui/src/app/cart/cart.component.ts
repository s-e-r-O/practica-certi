import { Component, OnInit } from '@angular/core';
import { ProductCart } from '../models/product-cart';
import { ProductCartService } from '../services/product-cart.service';
import { CartService } from '../services/cart.service';
import { UserService } from '../services/user.service';
import { Route, Router } from '@angular/router';

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

  constructor(private cartService : CartService, private userService : UserService, private router: Router) { 
    this.prices = [];
    this.totalPrice = 0;
    this.cartService.getById(this.userService.currentUser()).subscribe(
      response => { 
        this.products = response.productCarts; 
        this.productsCount = this.products.length;
        if (this.productsCount === 0){
          this.router.navigate(["/store"]);          
        }
      },
      error => {
        this.router.navigate(["/store"]);
      }
    );
  }

  ngOnInit() {  }
  
  addPrice($event){
    let ind : number;
    if((ind = this.prices.findIndex(p => p.code === $event.code))>-1){
      this.prices[ind].price = $event.price;
    } else {
      this.prices.push($event);
    }
    this.totalPrice = 0;
    this.prices.forEach(p => this.totalPrice += p.price);
  }
  onClick(){
    this.router.navigate(['/shipping'])
  }

  onDelete($event){

    this.cartService.updateProductNumbers();
    let index : number;

    if((index = this.products.findIndex(product => product.productCode === $event))> -1 ){
      this.products.splice(index,1);
      this.productsCount--;
      if((index = this.prices.findIndex(price => price.code === $event)) > -1 ){
        this.prices.splice(index,1);
        this.totalPrice = 0;
        this.prices.forEach(p => this.totalPrice += p.price);
      }
      if(this.productsCount === 0){
        this.router.navigate(["/store"]);
      }
    }
  }
}
