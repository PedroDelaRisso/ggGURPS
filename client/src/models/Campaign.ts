interface ICampaign {
    id: number;
    name: string;
    gameMasterId: number;
}

export default class Campaign implements ICampaign {
    public id: number;

    public name: string;

    public gameMasterId: number;

    constructor() {
        this.id = 0;
        this.name = '';
        this.gameMasterId = 0;
    }
}