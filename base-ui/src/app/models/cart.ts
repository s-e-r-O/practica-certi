import { ProductCart } from "./product-cart";

export class Cart {
    public productCarts : ProductCart[];
    public username : string;

    constructor(init? : Partial<Cart>){
        Object.assign(this, init);
    }
        
    set ProductCarts(value) {
        this.productCarts = value;
    }
    
    set Username(value) {
        this.username = value;
    }   
    get ProductCarts() {
        return this.productCarts;
    }
    
    get Username() {
        return this.username;
    }
}