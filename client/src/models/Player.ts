interface IPlayer {
    id: number;
    name: string;
}

export default class Player implements IPlayer {
    public id: number;

    public name: string;

    constructor() {
        this.id = 0;
        this.name = '';
    }
}