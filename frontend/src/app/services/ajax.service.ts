import { Injectable } from '@angular/core';
import axios from 'axios';

@Injectable({
  providedIn: 'root'
})
export class AjaxService {

  async post(url: string, dados: any) {
    let result = {};

    await axios.post(url, dados)
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
