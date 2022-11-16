import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { format, formatISO, parseISO } from 'date-fns';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';

import { HttpService } from '../../http.service';

const API = `${environment.api}`;
const TOKEN = 'session_token';
const LOGIN = 'session_login';
const EXPIRE = 'expire_token';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  public loadingBar: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(true);

  constructor(private http: HttpService,
              private router: Router) { }

  async login(req: string, value: any) {
    const result = await this.http.post(req, value).then((result: any) => result);
    if(result.success) {
      localStorage.setItem(TOKEN, result.data.accessToken);
      await this.http.get(`usuarios/nome/${value.usuario}`).then((retorno) => {
        delete retorno.senha;
        localStorage.setItem(LOGIN, JSON.stringify(retorno));
        localStorage.setItem(EXPIRE, formatISO(new Date()));
      });
      this.router.navigate(['/home']);
      return true;
    }else{
      return false;
    };
  };

  getUser(){
    const retorno: any = localStorage.getItem(LOGIN);
    return JSON.parse(retorno);
  }

  getToken() {
    return localStorage.getItem(TOKEN);
  };

  async getExpireToken(){
    return localStorage.getItem(EXPIRE)!;
  }

  async validateToken() {
    const validationInDays = 0;
    const validationInHours = 8;
    const newDate = new Date();
    const expireDate = new Date(parseISO(await this.getExpireToken().then(retorno => retorno)));


    //data e Hora do ultimo login
    const expireHours = Number(format(expireDate, 'hh'));

    //data e Hora atual
    const currentHours = Number(format(newDate, 'hh'));
    if(validationInDays !== 0){
      const differenceInDays = Math.floor(
        (new Date(expireDate.setDate(expireDate.getDate()+validationInDays)).getTime() - newDate.getTime()) / (1000 * 3600 * 24)
      );

      if(differenceInDays <= 0){
        localStorage.removeItem(TOKEN);
        return false;
      } else {
        return true;
      };
    } else {
      const differenceInDays = Math.floor((newDate.getTime() - expireDate.getTime()) / (1000 * 3600 * 24));
      const diferenceInHours = currentHours - expireHours;

      if(differenceInDays === 0){
        if(diferenceInHours >= validationInHours){
           localStorage.removeItem(TOKEN);
          return false;
        } else {
          return true;
        };
      } else {
         localStorage.removeItem(TOKEN);
        return false;
      };
    };
  };

  //CBO
  async loadCombo(req: string) {
    const ret: any = [];
    await this.http.get(`${API}/${req}`)
    .then((retorno: any) =>{
      retorno.data.forEach((value: any, index: number) => {
        if(value.ativo === 1){
          ret.push(value);
        };
      });
    });
    return ret;
  };
}
