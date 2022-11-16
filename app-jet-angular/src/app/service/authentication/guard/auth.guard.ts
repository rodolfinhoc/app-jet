import { Injectable } from '@angular/core';
import { CanActivate, CanLoad, Route, Router } from '@angular/router';

import { AuthService } from './auth-service.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate, CanLoad{

  constructor(private router: Router, private authService: AuthService) {}

  private async verificarAcesso() {

    if (this.authService.getToken() && await this.authService.validateToken().then(retorno => retorno)) {
      return true;
    } else {
      this.router.navigate(['login']);
      return false;
    };
  }

    async canActivate() {
      return await this.verificarAcesso().then(retorno => retorno);
    }

    async canLoad(route: Route) {
      return await this.verificarAcesso().then(retorno => retorno);
    }

};
