import { Store } from "./store";

export class ProductCart {
    public productCode : string;
    public selectedDelivery : number;
    public store : Store;
    public quantity : number;
}