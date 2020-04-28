import { Component, OnInit, Input } from '@angular/core';

import { IProgressIndicator } from '@shared/components/progress-indicator/progress-indicator.component';

import { EnrolmentRoutes } from '@enrolment/enrolment.routes';

@Component({
  selector: 'app-enrolment-progress-indicator',
  templateUrl: './enrolment-progress-indicator.component.html',
  styleUrls: ['./enrolment-progress-indicator.component.scss']
})
export class EnrolmentProgressIndicatorComponent implements OnInit, IProgressIndicator {
  @Input() public currentRoute: string;
  @Input() public inProgress: boolean;
  public routes: string[];

  public EnrolmentRoutes = EnrolmentRoutes;

  constructor() {
    this.routes = EnrolmentRoutes.initialEnrolmentRouteOrder();
  }

  public ngOnInit(): void { }
}