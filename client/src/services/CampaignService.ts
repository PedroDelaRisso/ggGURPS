import type { AxiosError, AxiosResponse } from "axios";
import type ICampaign from "../models/Campaign";
import Api from "./_Api";

export default class CampaignService {
  private static readonly _url = "Campaigns";

  public static async getAll(payload: any = {}) {
    return new Promise<Array<ICampaign>>((resolve, reject) => {
      Api.get(CampaignService._url, "", { params: payload })
        .then((response: AxiosResponse) => {
          resolve(response.data);
        })
        .catch((error: AxiosError) => {
          reject(error.response);
        });
    });
  }

  public static async create(payload: ICampaign) {
    return new Promise<ICampaign>((resolve, reject) => {
      Api.post(CampaignService._url, payload)
        .then((response: AxiosResponse) => {
          resolve(response.data);
        })
        .catch((error: AxiosError) => {
          reject(error.response);
        });
    });
  }

  public static async update(id: string, payload: ICampaign) {
    return new Promise<ICampaign>((resolve, reject) => {
      Api.put(CampaignService._url, id, payload)
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
      Api.delete(CampaignService._url, id)
        .then((response: AxiosResponse) => {
          resolve(response.data);
        })
        .catch((error: AxiosError) => {
          reject(error.response);
        });
    });
  }
}
