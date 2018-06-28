import { Category } from "./category";
import { ProductCart } from "./product-cart";
import { Store } from "./store";

export class Product {
    public code : string;
    public name : string;
    public price : string;
    public description : string;
    public type : string;
    public delivery : string;
    public imageURL : string;
    public category : Category;
    
    constructor(init? : Partial<Product>){
        Object.assign(this, init);
    }
    
    buildProductCart(quantity : number, user : string){
        return new ProductCart({ 
            "ProductCode":this.code, 
            "SelectedDelivery":this.delivery, 
            "Store": new Store({ "Name" : "Games", "Line1" : "Flying Av.", "Line2" : "Pallet Town", "Phone":12389499 }), 
            "Quantity": quantity, 
            "Username": user
        });
    }

    set Code(value) {
        this.code = value;
    }
    set Name(value) {
        this.name = value;
    }
    set Price(value) {
        this.price = value;
    }
    set Description(value) {
        this.description = value;
    }
    set Type(value) {
        this.type = value;
    }
    set Delivery(value) {
        this.delivery = value;
    }
    set ImageURL(value) {
        this.imageURL = value;
    }
    set Category(value) {
        this.category = value;
    }
    get Code() {
        return this.code;
    }
    get Name() {
        return this.name;
    }
    get Price() {
        return this.price;
    }
    get Description() {
        return this.description;
    }
    get Type() {
        return this.type;
    }
    get Delivery() {
        return this.delivery;
    }
    get ImageURL() {
        return this.imageURL;
    }
    get Category() {
        return this.category;
    }
}