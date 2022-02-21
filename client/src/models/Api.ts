export default class Api {
  private _fullUrl: string;

  private _headers = {
    "content-type": "application/json",
  }

  public async post(payload: any = {}) {
    return await fetch(this._fullUrl, {
      method: "POST",
      headers: this._headers,
      body: JSON.stringify(payload),
    });
  }

  public async getAll() {
    return await fetch(this._fullUrl);
  }

  public async get(id: number) {
    return await fetch(`${this._fullUrl}/${id}`);
  }

  public async update(id: number, payload: any = {}) {
    return await fetch(`${this._fullUrl}/${id}`, {
      method: 'PUT',
      headers: this._headers,
      body: JSON.stringify(payload),
    });
  }

  public async delete(id: number) {
    return await fetch(`${this._fullUrl}/${id}`, {
      method: 'DELETE',
      headers: this._headers,
    });
  }

  constructor(url: string) {
    this._fullUrl = `https://localhost:5001/api/${url}`;
  }
}