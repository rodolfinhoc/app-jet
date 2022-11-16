import { Platform } from '@angular/cdk/platform';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTableDataSource } from '@angular/material/table';
import { AuthService } from 'src/app/service/authentication/guard/auth-service.service';
import { HttpService } from 'src/app/service/http.service';

import { CadastroProdutoComponent } from './../../layout/dialogs/cadastro_produto/cadastroProduto.component';


@Component({
  selector: 'app-produtos',
  templateUrl: './produtos.component.html',
  styleUrls: ['./produtos.component.scss']
})
export class ProdutosComponent implements OnInit {
  dataSource: any;
  isLoading = true;
  displayedColumns: string[] = ['editar', 'codigo', 'nome', 'preco', 'preco_promocao', 'estoque', 'status', 'excluir'];
  @ViewChild(MatPaginator) paginator!: MatPaginator;


  constructor(
    public apiService: AuthService,
    private http: HttpService,
    private snackbar: MatSnackBar,
    public dialog: MatDialog,
    public platform: Platform
  ) {}

  async ngOnInit(){
    await this.loadTabela();
  }

  //TABLE
  async loadTabela(){
    await this.http.get(`produtos`).then(retorno => {
      this.dataSource = new MatTableDataSource(retorno.data);
      this.isLoading = false;
    });
    this.dataSource.paginator = this.paginator;
  }

  filtrar(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  //CRUD
  async excluir(codigo: any){
    this.http.delete(`produtos`,codigo).then(async retorno => {
      if(retorno.success){
        this.openSnackBar("Produto excluído com sucesso!");
        await this.loadTabela();
      }
    });
  };

  async inserirProduto(){
    const modal = this.dialog.open(CadastroProdutoComponent, {
      disableClose: true,
      data: {
        codigo: -1
      },
      maxWidth: '100vw',
      height: '85%',
      width: '85%',
    },);

    modal.afterClosed().subscribe(retorno => {
      this.loadTabela();
    });

  };

  async editar(codigo: any){
    const modal = this.dialog.open(CadastroProdutoComponent, {
      disableClose: true,
      data: {
        codigo: codigo
      },
      maxWidth: '100vw',
      height: '85%',
      width: '85%',
    },);

    modal.afterClosed().subscribe(retorno => {
      this.loadTabela();
    });
  };


  //SNACKBAR
  openSnackBar(message: string) {
    this.snackbar.open(message, "Fechar", {
      duration: 3000
    });
  };
}

