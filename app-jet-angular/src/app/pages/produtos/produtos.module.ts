import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { FileUploadModule } from 'ng2-file-upload';
import { CadastroProdutoComponent } from 'src/app/layout/dialogs/cadastro_produto/cadastroProduto.component';
import { AngularMaterialModule } from 'src/app/service/angular-material/angular-material.module';

import { ProdutosComponent } from './produtos.component';

@NgModule({
  declarations: [ProdutosComponent, CadastroProdutoComponent],
  imports: [
    BrowserModule,
    CommonModule,
    ReactiveFormsModule,
    FileUploadModule,
    HttpClientModule,
    AngularMaterialModule
  ],
  exports: [ProdutosComponent]
})
export class ProdutosModule { }
