import { ShippingAddress } from "./shipping-address";

export class User {
    public username : string;
    public password : string;
    public name : string;
    public lastName : string;
    public shipAdress : ShippingAddress[];
    
    constructor(init? : Partial<User>){
        Object.assign(this, init);
    }

    set Username(value) {
        this.username = value;
    }
    set Password(value) {
        this.password = value;
    }
    set Name(value) {
        this.name = value;
    }
    set LastName(value) {
        this.lastName = value;
    }
    set ShipAdress(value) {
        this.shipAdress = value;
    }
}