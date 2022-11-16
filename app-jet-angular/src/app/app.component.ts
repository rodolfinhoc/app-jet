import { Component, Injector } from '@angular/core';

import { ThemeService } from './service/theme.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'login';

  constructor(
    private injector: Injector
  ) { }

  async ngOnInit() {
    const theme = this.injector.get(ThemeService);
    theme.initTheme();
  }
}
