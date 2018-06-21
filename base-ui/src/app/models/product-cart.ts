import { Store } from "./store";

export class ProductCart {
    public productCode : string;
    public selectedDelivery : string;
    public store : Store;
    public quantity : number;
    public username : string;
    
    constructor(init? : Partial<ProductCart>){
        Object.assign(this, init);
    }
    
    set ProductCode(value) {
        this.productCode = value;
    }
    set Username(value) {
        this.username = value;
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
    get ProductCode() {
        return this.productCode;
    }
    get Username() {
        return this.username;
    }
    
    get SelectedDelivery() {
        return this.selectedDelivery;
    }
    
    get Store() {
        return this.store;
    }
    
    get Quantity() {
        return this.quantity;
    }
}