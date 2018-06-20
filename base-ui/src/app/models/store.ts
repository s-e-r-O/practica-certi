export class Store {
    public name : string;
    public line1 : string;
    public line2 : string;
    public phone : number;
    
    constructor(init? : Partial<Store>){
        Object.assign(this, init);
    }
}