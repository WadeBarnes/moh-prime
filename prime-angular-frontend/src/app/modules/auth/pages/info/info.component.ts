import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Inject } from '@angular/core';

import { APP_CONFIG, AppConfig } from 'app/app-config.module';
import { AuthProvider } from '@auth/shared/enum/auth-provider.enum';
import { AuthService } from '@auth/shared/services/auth.service';
import { EnrolmentRoutes } from '@enrolment/enrolment.routes';
import { UtilsService } from '@core/services/utils.service';

@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.scss']
})
export class InfoComponent implements OnInit {
  @ViewChild('learnmore', { static: true }) public learnMore: ElementRef;
  public isIE: boolean;

  constructor(
    @Inject(APP_CONFIG) private config: AppConfig,
    private authService: AuthService,
    private utilsService: UtilsService
  ) {
    this.isIE = this.utilsService.isIE();
  }

  public loginUsingBCSC() {
    // Send the user to COLLECTION_NOTICE which determines the direction of routing
    const redirectUri = `${this.config.loginRedirectUrl}${EnrolmentRoutes.routePath(EnrolmentRoutes.COLLECTION_NOTICE)}`;

    this.authService.login({
      idpHint: AuthProvider.BCSC,
      redirectUri
    });
  }

  public scrollTo() {
    this.utilsService.scrollTo(this.learnMore.nativeElement);
  }

  public ngOnInit() { }
}
