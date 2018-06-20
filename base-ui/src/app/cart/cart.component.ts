import { Component, OnInit } from '@angular/core';
import { ProductCart } from '../models/product-cart';
import { ProductCartService } from '../services/product-cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  private products : ProductCart[];
  private productsCount : number;
  private totalPrice : number;
  constructor(private productCartService : ProductCartService) { 
    this.productCartService.getAll().subscribe(
      response => { 
        this.products = response; 
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
