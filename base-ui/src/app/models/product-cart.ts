import { Store } from "./store";

export class ProductCart {
    public productCode : string;
    public selectedDelivery : string;
    public store : Store;
    public quantity : number;
    
    constructor(init? : Partial<ProductCart>){
        Object.assign(this, init);
    }
    
    set ProductCode(value) {
        this.productCode = value;
    }
    
    set SelectedDelivery(value) {
        this.selectedDelivery = value;
    }
    
    set Store(value) {
        this.store = value;
    }
    
    set Quantity(value) {
        this.quantity = value;
    }
}