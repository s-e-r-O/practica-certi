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
    get Identifier() {
        return this.identifier;
    }
    get Line1() {
        return this.line1;
    }
    get Line2() {
        return this.line2;
    }
    get Phone() {
        return this.phone;
    }
    get Username() {
        return this.username;
    }
    get City() {
        return this.city;
    }
    get Zone() {
        return this.zone;
    }
}