import { Component, OnInit, Input } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';
import { CartService } from '../services/cart.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  @Input() username : string;
  productCount : number;
  constructor(private cookieService : CookieService, private router : Router, private cartService : CartService) {
  }
  
  ngOnInit() {
    this.productCount = 0; 
    this.updateProductCount();
    this.cartService.addedProduct$.subscribe(
      () => { this.updateProductCount(); }
    )
  }

  private updateProductCount(){
    this.cartService.getById(this.username).subscribe(
      response => {
        this.productCount = response.productCarts.length;
      }, error => {
        this.productCount = 0;
      }
    )
  }

  onSignOut($event){
    this.cookieService.delete('Username');
    this.router.navigate(['/login']);
  }

}
