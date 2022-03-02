import type { AxiosError, AxiosResponse } from "axios";
import type IGameMaster from "../models/GameMaster";
import Api from "./_Api";

export default class GameMasterService {
  private static readonly _url = "GameMasters";

  public async getAll(payload: any = {}) {
    return new Promise<Array<IGameMaster>>((resolve, reject) => {
      Api.get(GameMasterService._url, "", { params: payload })
        .then((response: AxiosResponse) => {
          resolve(response.data);
        })
        .catch((error: AxiosError) => {
          reject(error.response);
        });
    });
  }

  public async create(payload: IGameMaster) {
    return new Promise<IGameMaster>((resolve, reject) => {
      Api.post(GameMasterService._url, payload)
        .then((response: AxiosResponse) => {
          resolve(response.data);
        })
        .catch((error: AxiosError) => {
          reject(error.response);
        });
    });
  }

  public async update(id: string, payload: IGameMaster) {
    return new Promise<IGameMaster>((resolve, reject) => {
      Api.put(GameMasterService._url, id, payload)
        .then((response: AxiosResponse) => {
          resolve(response.data);
        })
        .catch((error: AxiosError) => {
          reject(error.response);
        });
    });
  }

  public async remove(id: string) {
    return new Promise<any>((resolve, reject) => {
      Api.delete(GameMasterService._url, id)
        .then((response: AxiosResponse) => {
          resolve(response.data);
        })
        .catch((error: AxiosError) => {
          reject(error.response);
        });
    });
  }
}
