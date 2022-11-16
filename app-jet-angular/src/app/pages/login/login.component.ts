import { Component, Injector } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from 'src/app/service/authentication/guard/auth-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  hide = true;
  hideRegister = true;
  loading = false;
  loginForm = {
    username: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required, Validators.minLength(8)]),
  };

  constructor(
    private snackbar: MatSnackBar,
    public dialog: MatDialog,
    private injector: Injector
  ) {}

  openSnackBar(message: string) {
    this.snackbar.open(message, "Fechar", {
      duration: 3000
    });
  };

  async login() {
    this.loading = true;
    const authService = this.injector.get(AuthService);
    await authService.login('usuarios/login', {usuario: this.loginForm.username.value, senha: this.loginForm.password.value}).then(retorno => {
      if(retorno === false){
        this.openSnackBar('Usuário ou senha inválido!');
        this.loading = false;
      }
    });
  };

}
