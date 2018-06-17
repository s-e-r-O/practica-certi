import { Store } from "./store";

export class ProductCart {
    public productCode : string;
    public selectedDelivery : string;
    public store : Store;
    public quantity : number;
    
    constructor(init? : Partial<ProductCart>){
        Object.assign(this, init);
    }
}