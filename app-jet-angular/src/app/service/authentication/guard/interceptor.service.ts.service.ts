import { HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable, Injector } from '@angular/core';
import { AuthService } from './auth-service.service';

@Injectable({
  providedIn: 'root'
})
export class InterceptorService implements HttpInterceptor {

  constructor(private injector: Injector) { }

  intercept(req: HttpRequest<any>, next: HttpHandler) {
      const authService = this.injector.get(AuthService);
      let tokenReq = req.clone({
        setHeaders: {
          Authorization: `Bearer ${authService.getToken()}`
        }
      });

      return next.handle(tokenReq);
  }
}
