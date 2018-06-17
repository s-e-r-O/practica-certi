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
}