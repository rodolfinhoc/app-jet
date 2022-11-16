import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthenticationComponent } from './authentication.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [AuthenticationComponent],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
  ],
  exports: [AuthenticationComponent],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ]
})
export class AuthenticationModule { }
