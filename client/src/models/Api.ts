import axios from 'axios';

export default class Api {
  private _fullUrl: string;

  private _headers = {
    "content-type": "application/json",
  }

  public async post(payload: any = {}) {
    return await axios.post(this._fullUrl, payload)
    .then((response) => {
      return response.data;
    })
    .catch((error) => console.error(error));
  }

  public async getAll() {
    return await axios.get(this._fullUrl)
      .then((response) => {
        return response.data;
      })
      .catch((error) => console.error(error));
  }

  public async get(id: number) {
    return await axios.get(`${this._fullUrl}/${id}`)
      .then((response) => {
        return response.data;
      })
      .catch((error) => console.error(error));
  }

  public async update(id: number, payload: any = {}) {
    return await axios.put(`${this._fullUrl}/${id}`, payload)
      .then((response) => {
        return response.data;
      })
      .catch((error) => console.error(error));
  }

  public async delete(id: number) {
    return await axios.delete(`${this._fullUrl}/${id}`)
      .then((response) => {
        return response.data;
      })
      .catch((error) => console.error(error));
  }

  constructor(url: string) {
    this._fullUrl = `https://localhost:5001/api/${url}`;
  }
}