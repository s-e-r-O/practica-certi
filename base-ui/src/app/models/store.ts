export class Store {
    public name : string;
    public line1 : string;
    public line2 : string;
    public phone : number;
    
    constructor(init? : Partial<Store>){
        Object.assign(this, init);
    }
    

    set Line1(value) {
        this.line1 = value;
    }
    set Line2(value) {
        this.line2 = value;
    }
    set Name(value) {
        this.name = value;
    }
    set Phone(value) {
        this.phone = value;
    }
    get Line1() {
        return this.line1;
    }
    get Line2() {
        return this.line2;
    }
    get Name() {
        return this.name;
    }
    get Phone() {
        return this.phone;
    }
}