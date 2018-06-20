import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShippingAddressViewComponent } from './shipping-address-view.component';

describe('ShippingAddressViewComponent', () => {
  let component: ShippingAddressViewComponent;
  let fixture: ComponentFixture<ShippingAddressViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShippingAddressViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShippingAddressViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
