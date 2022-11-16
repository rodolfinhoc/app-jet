import { CommonModule } from '@angular/common';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AngularMaterialModule } from 'src/app/service/angular-material/angular-material.module';

import { HeaderComponent } from './header.component';
import { NavListModule } from './nav-list.module';

//** MATERIALS **/
@NgModule({
  declarations: [HeaderComponent],
  imports: [
    CommonModule,
    RouterModule,
    AngularMaterialModule,
    NavListModule
  ],
  exports: [HeaderComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class HeaderModule { }
