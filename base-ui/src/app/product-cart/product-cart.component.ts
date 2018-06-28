import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ProductCart } from '../models/product-cart';
import { Product } from '../models/product';
import { ProductService } from '../services/product.service';
import { Router } from '@angular/router';

@Component({
  selector: '[product-tr]',
  templateUrl: './product-cart.component.html',
  styleUrls: ['./product-cart.component.css']
})
export class ProductCartComponent implements OnInit {

  @Input('product-tr') productCart : ProductCart;
  @Output('price') price : EventEmitter<{code: string,price:number}> = new EventEmitter();
  private product : Product;
  constructor(private productService : ProductService, private router : Router) { }

  ngOnInit() {
    this.productService.getById(this.productCart.productCode).subscribe(
      response => { 
        this.product = response;
        this.price.emit({ code: this.product.code, price: this.product.price * this.productCart.quantity });
      }
    )
  }
  
  onClick(){
    this.router.navigate(['/product'],{queryParams: {id:this.productCart.productCode}});
  }

  onChange(){
    this.price.emit({ code: this.product.code, price: this.product.price * this.productCart.quantity })
  }

}
