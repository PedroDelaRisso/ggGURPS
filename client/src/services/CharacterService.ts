import type { AxiosError, AxiosResponse } from "axios";
import type ICharacter from "../models/Character";
import Api from "./_Api";

export default class CharacterService {
  private static readonly _url = "Characters";

  public static async getAll(payload: any = {}) {
    return new Promise<Array<ICharacter>>((resolve, reject) => {
      Api.get(CharacterService._url, "", { params: payload })
        .then((response: AxiosResponse) => {
          resolve(response.data);
        })
        .catch((error: AxiosError) => {
          reject(error.response);
        });
    });
  }

  public static async create(payload: ICharacter) {
    return new Promise<ICharacter>((resolve, reject) => {
      Api.post(CharacterService._url, payload)
        .then((response: AxiosResponse) => {
          resolve(response.data);
        })
        .catch((error: AxiosError) => {
          reject(error.response);
        });
    });
  }

  public static async update(id: string, payload: ICharacter) {
    return new Promise<ICharacter>((resolve, reject) => {
      Api.put(CharacterService._url, id, payload)
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
      Api.delete(CharacterService._url, id)
        .then((response: AxiosResponse) => {
          resolve(response.data);
        })
        .catch((error: AxiosError) => {
          reject(error.response);
        });
    });
  }
}
