import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { HomeModule } from 'src/app/pages/home/home.module';
import { LojaModule } from 'src/app/pages/loja/loja.module';

import { ProdutosModule } from '../../pages/produtos/produtos.module';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    HomeModule,
    ProdutosModule,
    LojaModule
  ]
})
export class NavListModule { }
