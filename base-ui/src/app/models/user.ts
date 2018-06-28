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
}