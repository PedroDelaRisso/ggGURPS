import type { AxiosError, AxiosResponse } from "axios";
import type IPlayer from "../models/Player";
import Api from "./_Api";

export default class PlayerService {
  private static readonly _url = "Players";

  public static async getAll(payload: any = {}) {
    return new Promise<Array<IPlayer>>((resolve, reject) => {
      Api.get(PlayerService._url, "", { params: payload })
        .then((response: AxiosResponse) => {
          resolve(response.data);
        })
        .catch((error: AxiosError) => {
          reject(error.response);
        });
    });
  }

  public static async create(payload: IPlayer) {
    return new Promise<IPlayer>((resolve, reject) => {
      Api.post(PlayerService._url, payload)
        .then((response: AxiosResponse) => {
          resolve(response.data);
        })
        .catch((error: AxiosError) => {
          reject(error.response);
        });
    });
  }

  public static async update(id: string, payload: IPlayer) {
    return new Promise<IPlayer>((resolve, reject) => {
      Api.put(PlayerService._url, id, payload)
        .then((response: AxiosResponse) => {
          resolve(response.data);
        })
        .catch((error: AxiosError) => {
          reject(error.response);
        });
    });
  }

  public static async remove(id: string) {
    return new Promise<any>((resolve, reject) => {
      Api.delete(PlayerService._url, id)
        .then((response: AxiosResponse) => {
          resolve(response.data);
        })
        .catch((error: AxiosError) => {
          reject(error.response);
        });
    });
  }
}
