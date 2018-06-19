import { Component, OnInit } from '@angular/core';
import { ProductService } from '../services/product.service';
import { Product } from '../models/product';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  products: Product[];

  constructor(private productService: ProductService, private router: Router) { }

  ngOnInit() {
    this.getproduct();
  }
  getproduct(){
    this.productService.getAll()
    .subscribe(products => this.products = products);
  }
  onClick(code:String){
    this.router.navigate(['/product-details'],{queryParams: {id:code}});
  }

}
