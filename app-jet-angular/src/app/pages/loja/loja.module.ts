import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { VisualizarProdutoComponent } from 'src/app/layout/dialogs/visualizar_produto/visualizarProduto.component';
import { AngularMaterialModule } from 'src/app/service/angular-material/angular-material.module';

import { LojaComponent } from './loja.component';

@NgModule({
  declarations: [LojaComponent, VisualizarProdutoComponent],
  imports: [
    BrowserModule,
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
    AngularMaterialModule
  ],
  exports: [LojaComponent]
})
export class LojaModule { }
