import { Component, EventEmitter, OnInit, Output } from '@angular/core';

import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';

import { ViewportService } from '@core/services/viewport.service';
import { BannerLocationCode } from '@shared/enums/banner-location-code.enum';

@UntilDestroy()
@Component({
  selector: 'app-prime-enrolment-access',
  templateUrl: './prime-enrolment-access.component.html',
  styleUrls: [
    './prime-enrolment-access.component.scss',
    '../access.component.scss'
  ]
})
export class PrimeEnrolmentAccessComponent implements OnInit {
  @Output() public login: EventEmitter<void>;
  public locationCode: BannerLocationCode;

  constructor(
    private viewportService: ViewportService
  ) {
    this.login = new EventEmitter<void>();
    this.locationCode = BannerLocationCode.ENROLMENT_LANDING_PAGE;
  }

  public get isMobile(): boolean {
    return this.viewportService.isMobile;
  }

  public onLogin() {
    this.login.emit();
  }

  public ngOnInit(): void {
    this.viewportService.onResize()
      .pipe(untilDestroyed(this))
      .subscribe();
  }
}
