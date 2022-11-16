import { Component } from '@angular/core';

import { ThemeService } from '../../service/theme.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  darkTheme: boolean;
  srcImage!: string;

  constructor(
    private themeService: ThemeService
  ){
    this.darkTheme = this.themeService.isDarkMode();
  }

};
