export class Category {
    public name : string;
    public description : string;
    
    constructor(init? : Partial<Category>){
        Object.assign(this, init);
    }
}