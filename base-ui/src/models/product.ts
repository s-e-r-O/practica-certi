import { Category } from "./category";

export class Product {
    public code : string;
    public name : string;
    public price : string;
    public description : string;
    public type : number;
    public delivery : number;
    public category : Category;
}