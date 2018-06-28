import { Category } from "./category";
import { ProductCart } from "./product-cart";
import { Store } from "./store";

export class Product {
    public code : string;
    public name : string;
    public price : number;
    public description : string;
    public type : string;
    public shippingDeliveryType : string;
    public imageURL : string;
    public category : Category;
    
    constructor(init? : Partial<Product>){
        Object.assign(this, init);
    }
    
    buildProductCart(quantity : number, user : string){
        return new ProductCart({ 
            productCode:this.code, 
            selectedDelivery:this.shippingDeliveryType, 
            quantity: quantity, 
            username: user,
            store: new Store({ name : "Only Cereals", line1 : "Dream St.", line2 : "Oakland", phone:41204930 })
        });
    }
}