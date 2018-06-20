import { Category } from "./category";

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
}