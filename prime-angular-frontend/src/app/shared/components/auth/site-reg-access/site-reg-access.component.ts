import { Component, EventEmitter, OnInit, Output } from '@angular/core';

import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';

import { ViewportService } from '@core/services/viewport.service';

@UntilDestroy()
@Component({
  selector: 'app-site-reg-access',
  templateUrl: './site-reg-access.component.html',
  styleUrls: [
    './site-reg-access.component.scss',
    '../access.component.scss'
  ]
})
export class SiteRegAccessComponent implements OnInit {
  @Output() public login: EventEmitter<void>;

  constructor(
    private viewportService: ViewportService
  ) {
    this.login = new EventEmitter<void>();
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