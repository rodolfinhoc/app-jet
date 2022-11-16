import { Platform } from '@angular/cdk/platform';
import { CdkTextareaAutosize } from '@angular/cdk/text-field';
import { Component, Inject, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSidenav } from '@angular/material/sidenav';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FileItem, FileUploader } from 'ng2-file-upload';
import { AuthService } from 'src/app/service/authentication/guard/auth-service.service';
import { HttpService } from 'src/app/service/http.service';

import { FormCadastroProdutoInterface } from './Interface/cadastroProduto.interface';

@Component({
  selector: 'app-cadastro-produto',
  templateUrl: './cadastroProduto.component.html',
  styleUrls: ['./cadastroProduto.component.scss']
})
export class CadastroProdutoComponent {
  @ViewChild(MatSidenav) sideNav!: MatSidenav;
  @ViewChild('autosize') autosize!: CdkTextareaAutosize;
  @ViewChild('fileInput') fileInput: any;
  cadastroProdutoForm!: FormGroup;
  public fileUploader: FileUploader = new FileUploader({});
  arquivo!: String;
  fileName: string[] = [];
  private imageSrc: string[] = [];
  loading = false;

  constructor(
    public dialogRef: MatDialogRef<CadastroProdutoComponent>,
    public apiService: AuthService,
    private http: HttpService,
    private snackbar: MatSnackBar,
    public dialog: MatDialog,
    public platform: Platform,
    fb: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: any
    ) {
      this.cadastroProdutoForm = fb.group(new FormCadastroProdutoInterface());
    }


  async ngOnInit() {
    if(this.data.codigo !== -1){
      await this.http.get(`produtos/` + this.data.codigo).then(retorno => {
        if(retorno.success){
          this.cadastroProdutoForm.patchValue({
            nome: retorno.data[0].nome,
            descricao: retorno.data[0].descricao,
            estoque: retorno.data[0].estoque,
            preco: retorno.data[0].preco,
            preco_promocao: retorno.data[0].preco_promocao,
            status: retorno.data[0].status
          });
        }
      });
    }
  };

  close() {
    this.dialogRef.close();
  }

  async salvar(){
    if(this.data.codigo === -1){
      this.loading = true;
      await this.http.post(`produtos`,this.cadastroProdutoForm.value).then(retorno => {
        if(retorno.success){
          this.loading = false;
          this.openSnackBar(retorno.message);
          this.close();
        }
      });
    }else{
      this.loading = true;
      await this.http.put(`produtos`, this.data.codigo, this.cadastroProdutoForm.value).then(retorno => {
        if(retorno.success){
          this.loading = false;
          this.openSnackBar(retorno.message);
          this.close();
        }
      });
    }
  }

  onFileChange() {
    let fileCount: number = this.fileUploader.queue.length;
    if (fileCount > 0) {
    this.fileUploader.queue.forEach((val, i, array) => {
        let fileReader = new FileReader();
        fileReader.onloadend = (e) => {
            let imageData = fileReader.result as string;
            this.imageSrc.push(imageData);
            this.cadastroProdutoForm.patchValue({
              imagem: imageData
            });
        }
        fileReader.readAsDataURL(val._file);
    });
    }
  }

  removeFile(item: FileItem){
    this.fileInput.nativeElement.value = '';
    this.fileUploader.removeFromQueue(item);
    this.cadastroProdutoForm.patchValue({
      imagem: ''
    });
    this.openSnackBar("Imagem Removida com Sucesso!");
  };


  //SNACKBAR
  openSnackBar(message: string) {
    this.snackbar.open(message, "Fechar", {
      duration: 3000
    });
  };

}
