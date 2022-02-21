import Api from '../models/Api';
import type IGameMaster from '../models/GameMaster';

export default class GameMasterService {
    private _URL = 'GameMasters'

    private api = new Api(this._URL);

    public async Create(gameMaster: IGameMaster) {
        return await this.api.post(gameMaster);
    }

    public async GetAll() {
        return await this.api.getAll();
    }

    public async Edit(id: number, gamemMaster: IGameMaster) {
        return await this.api.update(id, gamemMaster);
    }

    public async Remove(id: number) {
        return await this.api.delete(id);
    }
}