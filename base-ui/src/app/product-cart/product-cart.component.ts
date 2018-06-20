import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ProductCart } from '../models/product-cart';
import { Product } from '../models/product';
import { ProductService } from '../services/product.service';

@Component({
  selector: '[product-tr]',
  templateUrl: './product-cart.component.html',
  styleUrls: ['./product-cart.component.css']
})
export class ProductCartComponent implements OnInit {

  @Input('product-tr') productCart : ProductCart;
  @Output('price') price : EventEmitter<number> = new EventEmitter();
  private product : Product;
  constructor(private productService : ProductService) { }

  ngOnInit() {
    this.productService.getById(this.productCart.productCode).subscribe(
      response => { 
        this.product = response;
        this.price.emit(+this.product.price.replace('$','') * this.productCart.quantity);
      }
    )
  }

}
