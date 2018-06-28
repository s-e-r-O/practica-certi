import { Component, OnInit } from '@angular/core';
import { Product } from '../models/product';
import { ProductService } from '../services/product.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-products',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.css']
})
export class StoreComponent implements OnInit {
  products: Product[];

  constructor(private productService: ProductService, private router: Router) { }

  ngOnInit() {
    this.getproduct();
  }
  getproduct(){
    this.productService.getAll()
    .subscribe(products => this.products = products);
  }
}