import { Validators } from "@angular/forms";

export class FormCadastroProdutoInterface{
  public nome = ['', [Validators.required]];
  public descricao = ['', [Validators.required]];
  public estoque = ['', [Validators.required]];
  public imagem = [''];
  public preco = ['', [Validators.required]];
  public preco_promocao = ['', [Validators.required]];
  public status = [false, [Validators.required]];

};
