export class ShippingAddress {
    public identifier : string;
    public line1 : string;
    public line2 : string;
    public phone : number;
    public city : string;
    public zone : string;
    public username : string;
    
    constructor(init? : Partial<ShippingAddress>){
        Object.assign(this, init);
    }
    

    set Identifier(value) {
        this.identifier = value;
    }
    set Line1(value) {
        this.line1 = value;
    }
    set Line2(value) {
        this.line2 = value;
    }
    set Phone(value) {
        this.phone = value;
    }
    set Username(value) {
        this.username = value;
    }
    set City(value) {
        this.city = value;
    }
    set Zone(value) {
        this.zone = value;
    }
}