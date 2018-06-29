import { Component, OnInit } from '@angular/core';
import { ProductService } from '../services/product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../models/product';
import { ProductCartService } from '../services/product-cart.service';
import { UserService } from '../services/user.service';
import { CartService } from '../services/cart.service';
import { Cart } from '../models/cart';



@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  id:string;
  product: Product;
  quantity: number = 1;
  constructor(private productService: ProductService, private router: Router, private route: ActivatedRoute, 
    private productCartService : ProductCartService, private userService : UserService, private cartService : CartService) { }

  ngOnInit() {
    this.route.queryParams
      .subscribe(params =>{
        this.id = params.id;
        this.productService.getById(this.id).subscribe(product => this.product = product);
      })
  }
  onClick($event){
    $event.preventDefault();
    this.productCartService.create(this.product.buildProductCart(this.quantity, this.userService.currentUser())).subscribe(
      response => {
        this.router.navigate(['/cart']);
      },
      error => {
        this.router.navigate(['/cart']);
      }
    );
  }
}
