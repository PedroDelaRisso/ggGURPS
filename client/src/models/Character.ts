interface ICharacter {
    id: number;
    name: string;
    strength: number;
    dexterity: number;
    inteligence: number;
    health: number;
    perception: number;
    will: number;
    magery: number;
    damageReduction: number;
    hitPoints: number;
    fatiguePoints: number;
    energyReserve: number;
}

export default class Character implements ICharacter {
    
    public id: number;
    public name: string;
    public strength: number;
    public dexterity: number;
    public inteligence: number;
    public health: number;
    public perception: number;
    public will: number;
    public magery: number;
    public damageReduction: number;
    public hitPoints: number;
    public fatiguePoints: number;
    public energyReserve: number;

    constructor() {
        this.id = 0;
        this.name = '';
        this.strength = 10;
        this.dexterity = 10;
        this.inteligence = 10;
        this.health = 10;
        this.perception = 10;
        this.will = 10;
        this.magery = 0;
        this.damageReduction = 0;
        this.energyReserve = 0;
        this.hitPoints = 10;
        this.fatiguePoints = 10;
    }
}