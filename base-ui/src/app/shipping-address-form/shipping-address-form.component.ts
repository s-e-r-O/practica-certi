import { Component, Input, OnChanges, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ShippingAddress } from '../models/shipping-address';
import { ShippingAddressService } from '../services/shipping-address.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-shipping-address-form',
  templateUrl: './shipping-address-form.component.html',
  styleUrls: ['./shipping-address-form.component.css']
})

export class ShippingAddressFormComponent implements OnChanges {

  @Input() shippingAddress : ShippingAddress;
  @Output() cancel : EventEmitter<boolean> = new EventEmitter();
  @Output() create : EventEmitter<boolean> = new EventEmitter();
  private form : FormGroup;
  
  constructor(private shippingAddressService : ShippingAddressService) { 
    this.form = new FormGroup({
      'line1' : new FormControl(undefined,Validators.required),
      'line2' : new FormControl(undefined,Validators.required),
      'city' : new FormControl(undefined,Validators.required),
      'phone' : new FormControl(undefined,Validators.required),
      'zone' : new FormControl(undefined,Validators.required)
    })
  }

  ngOnChanges() {
    if (this.shippingAddress) {
      this.form.patchValue(this.shippingAddress);
    } else {
      this.form.reset();
    }
  }

  onSubmit($event){
    $event.preventDefault();
    
    for (let field in this.form.controls) {
        this.form.controls[field].markAsTouched();
    }

    if (this.form.valid){
      if (this.shippingAddress) {
        this.shippingAddressService.update(new ShippingAddress(this.form.value)).subscribe(response => {
          this.create.emit(true);
          this.form.reset();
        });
      } else {
        this.shippingAddressService.create(new ShippingAddress(this.form.value)).subscribe(response => {
          this.create.emit(true)
          this.form.reset();
        });
      }
    }
  }

  onCancel($event){
    $event.preventDefault();
    this.form.reset();
    this.cancel.emit(true);
  }

}
