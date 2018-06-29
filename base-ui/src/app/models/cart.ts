import { ProductCart } from "./product-cart";
import { ShippingAddress } from "./shipping-address";

export class Cart {
    public productCarts : ProductCart[];
    public username : string;
    public shippingAddress : ShippingAddress;

    constructor(init? : Partial<Cart>){
        Object.assign(this, init);
    }
}