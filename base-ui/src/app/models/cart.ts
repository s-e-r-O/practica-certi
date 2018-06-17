import { ProductCart } from "./product-cart";

export class Cart {
    public productCarts : ProductCart[];
    public username : string;

    constructor(init? : Partial<Cart>){
        Object.assign(this, init);
    }
}