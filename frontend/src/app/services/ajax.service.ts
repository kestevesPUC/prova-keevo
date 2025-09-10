import { Injectable } from '@angular/core';
import axios from 'axios';

@Injectable({
  providedIn: 'root'
})
export class AjaxService {

  async post(url: string, dados: any): Promise<any> {
    let result = {};

    await axios.post(url, dados, {
      headers: {
        'Content-Type': 'application/json'
      }
    })
      .then((response) => {
        result = response.data
      })
      .catch((error) => {
        console.log(`Erro: ${error}`);

        result = {
          success: false,
          status: 400,
          message: "Falha ao fazer a requisição!"
        }
      });

    return result;
  }

  async get(url: string): Promise<any> {
    let result = {};
    await axios.get(url, {
      headers: {
        'Content-Type': 'application/json'
      }
    }).then((response) => {
      result = response.data
    })
      .catch((error) => {
        console.log(`Erro: ${error}`);

        result = {
          success: false,
          status: 400,
          message: "Falha ao fazer a requisição!"
        }
      });

    return result;
  }

  async delete(url: string, id: number): Promise<any> {
    let result = {};
    await axios.delete(`${url}/${id}`)
      .then((response) => {
        result = response.data
      })
      .catch((error) => {
        console.log(`Erro: ${error}`);

        result = {
          success: false,
          status: 400,
          message: "Falha ao fazer a requisição!"
        }
      });

    return result;


  }
  async put(url: string, dados: any): Promise<any> {
    let result = {};
    await await axios.put(`${url}`, dados)
      .then((response) => {
        result = response.data
      })
      .catch((error) => {
        console.log(`Erro: ${error}`);

        result = {
          success: false,
          status: 400,
          message: "Falha ao fazer a requisição!"
        }
      });

    return result;


  }
}
