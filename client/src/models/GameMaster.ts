interface IGameMaster {
    id: number;
    name: string;
}

export default class GameMaster implements IGameMaster {
    public id: number;

    public name: string;

    constructor() {
        this.id = 0;
        this.name = '';
    }
}