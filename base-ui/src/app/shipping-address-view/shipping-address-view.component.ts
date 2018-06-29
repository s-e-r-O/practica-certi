import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ShippingAddress } from '../models/shipping-address';
import { ShippingAddressService } from '../services/shipping-address.service';
import { Router } from '@angular/router';
import { CartService } from '../services/cart.service';

@Component({
  selector: 'app-shipping-address-view',
  templateUrl: './shipping-address-view.component.html',
  styleUrls: ['./shipping-address-view.component.css']
})
export class ShippingAddressViewComponent implements OnInit {

  @Input() shippingAddress : ShippingAddress;
  @Output() edit : EventEmitter<ShippingAddress> = new EventEmitter();
  @Output() delete : EventEmitter<ShippingAddress> = new EventEmitter();

  constructor(private shippingAddressService : ShippingAddressService, private router : Router, private cartService : CartService) { }

  ngOnInit() {
  }

  onEdit($event){
    $event.preventDefault();
    this.edit.emit(this.shippingAddress);
  }

  onDelete($event){
    $event.preventDefault();    
    this.shippingAddressService.delete(this.shippingAddress.identifier).subscribe(
      response => {
        this.delete.emit(this.shippingAddress);
      }
    );
  }
  onClick($event){
    $event.preventDefault();
    this.cartService.delete().subscribe(
      response =>  {
        this.cartService.updateProductNumbers();
        this.router.navigate(["/store"]);
      } 
    )
   

  }
}
