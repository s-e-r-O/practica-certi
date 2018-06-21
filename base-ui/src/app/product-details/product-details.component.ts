import { Component, OnInit } from '@angular/core';
import { ProductService } from '../services/product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../models/product';
import { ProductCartService } from '../services/product-cart.service';
import { ProductCart } from '../models/product-cart';
import { Store } from '../models/store';



@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  id:string;
  product: Product;
  constructor(private productService: ProductService, private router: Router, private route: ActivatedRoute, private productCartService : ProductCartService) { }

  ngOnInit() {
    this.route.queryParams
      .subscribe(params =>{
        this.id = params.id;
        this.productService.getById(this.id).subscribe(product => this.product = product);
      })
  }
  onClick($event){
    $event.preventDefault();
    console.log('hola');
    var productCart = new ProductCart({ "ProductCode":this.product.code, "SelectedDelivery":"Express", "Store":
    new Store({ "Name" : "Games", "Line1" : "Flying Av.", "Line2" : "Pallet Town", "Phone":12389499 }), "Quantity":1 , "Username":"lol1" });
    this.productCartService.create(productCart).subscribe(
      response => {
        console.log(response);
      },
      error => {
        console.log(error);
      }
    );
  }

}
