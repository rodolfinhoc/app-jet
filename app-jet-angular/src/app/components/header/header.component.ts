import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef, Component, EventEmitter, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthGuard } from 'src/app/service/authentication/guard/auth.guard';
import { ThemeService } from 'src/app/service/theme.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
  @Output() toggleDarkMode = new EventEmitter<any>();

  darkTheme: boolean;
  mobileQuery: MediaQueryList;
  rotaHome = '/home';

  constructor(
    public dialog: MatDialog,
    private themeService: ThemeService,
    private changeDetectorRef: ChangeDetectorRef,
    private media: MediaMatcher,
    private route: ActivatedRoute,
    private router: Router,
    private authGuard: AuthGuard
  ) {
    this.darkTheme = this.themeService.isDarkMode();
    this.mobileQuery = media.matchMedia('(max-width: 3000px)');
  };

  //FUNÇÕES
  darkMode() {
    this.darkTheme = this.themeService.isDarkMode();
    this.darkTheme ? this.themeService.update('light-mode') : this.themeService.update('dark-mode');
  };

  sair() {
    window.localStorage.clear();
    this.router.navigate(['/login']);
  };
};
