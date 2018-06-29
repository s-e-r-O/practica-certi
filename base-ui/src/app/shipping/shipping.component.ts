import { Component, OnInit } from '@angular/core';
import { ShippingAddress } from '../models/shipping-address';
import { ShippingAddressService } from '../services/shipping-address.service';

@Component({
  selector: 'app-shipping',
  templateUrl: './shipping.component.html',
  styleUrls: ['./shipping.component.css']
})
export class ShippingComponent implements OnInit {

  private shippingAddresses : ShippingAddress[] = [];
  private shippingAddressToEdit : ShippingAddress;

  constructor(private shippingAddressService : ShippingAddressService) { 
    this.shippingAddressService.getAll().subscribe(
      response => {
        this.shippingAddresses = response;
        console.log(response);
      }
    )
  }

  ngOnInit() {

  }

  onEdit($event){
    this.shippingAddressToEdit = $event;
  }

  onCancel($event){
    if ($event){
      this.shippingAddressToEdit = undefined;
    }
  }

  onDelete($event){
    this.shippingAddressService.getAll().subscribe(
      response => {
        this.shippingAddresses = response;
        if (this.shippingAddressToEdit.identifier === $event.identifier){
          this.shippingAddressToEdit = undefined;
        }
      }
    )
  }

  onCreate($event){
    this.shippingAddressService.getAll().subscribe(
      response => {
        this.shippingAddresses = response;
      }
    )
  }

}
