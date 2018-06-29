import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ProductCart } from '../models/product-cart';
import { Product } from '../models/product';
import { ProductService } from '../services/product.service';
import { Router } from '@angular/router';
import { ProductCartService } from '../services/product-cart.service';
import { UserService } from '../services/user.service';
import { User } from '../models/user';

@Component({
  selector: '[product-tr]',
  templateUrl: './product-cart.component.html',
  styleUrls: ['./product-cart.component.css']
})
export class ProductCartComponent implements OnInit {

  @Input('product-tr') productCart : ProductCart;
  @Output('price') price : EventEmitter<{code: string,price:number}> = new EventEmitter();
  @Output('delete') delete : EventEmitter<string> = new EventEmitter();

  private product : Product;
  private disableDelete : boolean;

  constructor(private productService : ProductService, private router : Router, private productCartService : ProductCartService, private userService: UserService) { }

  ngOnInit() {
    this.disableDelete = true;
    this.productService.getById(this.productCart.productCode).subscribe(
      response => { 
        this.product = response;
        this.price.emit({ code: this.product.code, price: this.product.price * this.productCart.quantity });
        this.disableDelete = false;
      }
    )
  }
  
  onClick(){
    this.router.navigate(['/product'],{queryParams: {id:this.productCart.productCode}});
  }

  onChange(){
    this.price.emit({ code: this.product.code, price: this.product.price * this.productCart.quantity });
    this.productCartService.update(this.productCart).subscribe(
      response => { }, error => { console.log(error); }
    )
  }

  onDelete(){
    this.disableDelete = true;
    this.productCartService.delete(this.product.code,this.userService.currentUser()).subscribe(
      response => { this.delete.emit(this.product.code);}, 
      err => { 
        console.log(err); 
        this.disableDelete = false;
      }
    );
  }

}
