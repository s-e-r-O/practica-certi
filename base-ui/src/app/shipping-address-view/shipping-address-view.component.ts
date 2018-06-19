import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ShippingAddress } from '../models/shipping-address';
import { ShippingAddressService } from '../services/shipping-address.service';

@Component({
  selector: 'app-shipping-address-view',
  templateUrl: './shipping-address-view.component.html',
  styleUrls: ['./shipping-address-view.component.css']
})
export class ShippingAddressViewComponent implements OnInit {

  @Input() shippingAddress : ShippingAddress;
  @Output() edit : EventEmitter<ShippingAddress> = new EventEmitter();
  @Output() delete : EventEmitter<ShippingAddress> = new EventEmitter();

  constructor(private shippingAddressService : ShippingAddressService) { }

  ngOnInit() {
  }

  onEdit($event){
    $event.preventDefault();
    this.edit.emit(this.shippingAddress);
  }

  onDelete($event){
    $event.preventDefault();
    this.shippingAddressService.delete(this.shippingAddress).subscribe(
      response => {
        this.delete.emit(this.shippingAddress);
      }
    );
  }
}
