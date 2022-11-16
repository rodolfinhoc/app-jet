import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HeaderComponent } from './components/header/header.component';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { LojaComponent } from './pages/loja/loja.component';
import { ProdutosComponent } from './pages/produtos/produtos.component';
import { AuthenticationComponent } from './service/authentication/authentication.component';
import { AuthGuard } from './service/authentication/guard/auth.guard';


const routes: Routes = [
  {
    path: '',
    component: HeaderComponent,
    children: [
      { path: 'home', component: HomeComponent },
      { path: 'produtos', component: ProdutosComponent },
      { path: 'loja', component: LojaComponent },
    ],
    canActivate: [AuthGuard],
    canLoad: [AuthGuard]
  },
  {
    path: '',
    component: AuthenticationComponent,
    children: [
      { path: '', redirectTo: 'login', pathMatch: 'full' },
      { path: 'login', component: LoginComponent }
    ]
  },
  { path: '***', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
