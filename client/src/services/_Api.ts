import type { AxiosResponse } from 'axios';
import { stringify } from 'qs';
import api from '../config/api';

export default class Api {
    public static get(url: string, id: string = '', payload: any = {}): Promise<AxiosResponse> {
        const config = {
            params: payload.params,
            paramsSerializer: (data: any) => stringify(data),
        };

        return new Promise<AxiosResponse>((resolve) => {
            resolve(api.get(`${url}/${id}`, config));
        });
    }

    public static post<T>(url: string, data: T, params: object = {}): Promise<AxiosResponse> {
        return new Promise<AxiosResponse>((resolve) => {
            resolve(api.post(url, data, params));
        });
    }

    public static put<T>(url: string, id: string,data: T): Promise<AxiosResponse> {
        return new Promise<AxiosResponse>((resolve) => {
            resolve(api.put(`${url}/${id}`, data))
        });
    }

    public static delete(url: string, id: string): Promise<AxiosResponse> {
        return new Promise<AxiosResponse>((resolve) => {
            resolve(api.delete(`${url}/${id}`));
        })
    }
}