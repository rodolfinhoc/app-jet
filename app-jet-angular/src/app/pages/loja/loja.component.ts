import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { VisualizarProdutoComponent } from 'src/app/layout/dialogs/visualizar_produto/visualizarProduto.component';
import { HttpService } from 'src/app/service/http.service';

@Component({
  selector: 'app-loja',
  templateUrl: './loja.component.html',
  styleUrls: ['./loja.component.scss']
})
export class LojaComponent implements OnInit {
  dados!: any[];
  isLoading = true;

  constructor(private http: HttpService,
              public dialog: MatDialog) { }

  async ngOnInit() {
    this.loadCards();
  };

  async loadCards(){
    await this.http.get(`produtos/card`).then(retorno => {
      this.dados = retorno.data;
    });
  };

  async visualizar(codigo: number){
    const modal = this.dialog.open(VisualizarProdutoComponent, {
      data: {
        codigo: codigo
      },
      maxWidth: '100vw',
      width: '850px',
    },);

    modal.afterClosed().subscribe(retorno => {
      this.loadCards();
    });
  };

}
