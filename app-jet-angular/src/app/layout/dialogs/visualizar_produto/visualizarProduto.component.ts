import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { AuthService } from 'src/app/service/authentication/guard/auth-service.service';
import { HttpService } from 'src/app/service/http.service';

@Component({
  selector: 'app-visualizar-produto',
  templateUrl: './visualizarProduto.component.html',
  styleUrls: ['./visualizarProduto.component.scss']
})
export class VisualizarProdutoComponent {
  titulo!: string;
  imagem!: string;
  preco_promocao!: number;
  preco!: number;
  descricao!: string;
  estoque!: number;

  constructor(
    public dialogRef: MatDialogRef<VisualizarProdutoComponent>,
    public apiService: AuthService,
    private http: HttpService,
    public dialog: MatDialog,
    @Inject(MAT_DIALOG_DATA) public data: any
    ) {
    }


  async ngOnInit() {
    await this.http.get(`produtos/` + this.data.codigo).then(retorno => {
      if(retorno.success){
        this.titulo = retorno.data[0].nome;
        this.imagem = retorno.data[0].imagem;
        this.preco_promocao = retorno.data[0].preco_promocao;
        this.preco = retorno.data[0].preco;
        this.descricao = retorno.data[0].descricao;
        this.estoque = retorno.data[0].estoque;
      }
    });
  };

  close() {
    this.dialogRef.close();
  }

}
