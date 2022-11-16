import { LayoutModule } from '@angular/cdk/layout';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderModule } from './components/header/header.module';
import { LoginModule } from './pages/login/login.module';
import { LojaModule } from './pages/loja/loja.module';
import { ProdutosModule } from './pages/produtos/produtos.module';
import { AuthenticationModule } from './service/authentication/authentication.module';
import { InterceptorService } from './service/authentication/guard/interceptor.service.ts.service';

//** MATERIALS ANGULAR **/
@NgModule({
  declarations: [AppComponent],
  imports: [
    AuthenticationModule,
    LoginModule,
    HeaderModule,
    ProdutosModule,
    LojaModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LayoutModule
  ],
  providers: [{provide: HTTP_INTERCEPTORS, useClass: InterceptorService, multi: true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
