import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ConfigResolver } from '@config/config-resolver';
import { CanDeactivateFormGuard } from '@core/guards/can-deactivate-form.guard';
import { DashboardComponent } from '@shared/components/dashboard/dashboard.component';
import { AuthenticationGuard } from '@auth/shared/guards/authentication.guard';

import { EnrolleeGuard } from './shared/guards/enrollee.guard';
import { EnrolmentGuard } from './shared/guards/enrolment.guard';

import { ProfileComponent } from './pages/profile/profile.component';
import { ProfessionalInfoComponent } from './pages/professional-info/professional-info.component';
import { SelfDeclarationComponent } from './pages/self-declaration/self-declaration.component';
import { PharmanetAccessComponent } from './pages/pharmanet-access/pharmanet-access.component';
import { ReviewComponent } from './pages/review/review.component';
import { ConfirmationComponent } from './pages/confirmation/confirmation.component';
import { AccessAgreementComponent } from './pages/access-agreement/access-agreement.component';
import { SummaryComponent } from './pages/summary/summary.component';

const routes: Routes = [
  {
    path: 'enrolment',
    component: DashboardComponent,
    // Check authentication and authorization each time
    // the router navigates to the next route
    canActivateChild: [
      AuthenticationGuard,
      // Guard module from being accessed without the proper
      // authorization based on the user role permissions
      EnrolleeGuard
    ],
    resolve: [ConfigResolver],
    children: [
      {
        path: 'profile',
        component: ProfileComponent,
        canActivate: [EnrolmentGuard],
        canDeactivate: [CanDeactivateFormGuard]
      },
      {
        path: 'professional',
        component: ProfessionalInfoComponent,
        canActivate: [EnrolmentGuard],
        canDeactivate: [CanDeactivateFormGuard]
      },
      {
        path: 'declaration',
        component: SelfDeclarationComponent,
        canActivate: [EnrolmentGuard],
        canDeactivate: [CanDeactivateFormGuard]
      },
      {
        path: 'access',
        component: PharmanetAccessComponent,
        canActivate: [EnrolmentGuard],
        canDeactivate: [CanDeactivateFormGuard]
      },
      {
        path: 'review',
        canActivate: [EnrolmentGuard],
        component: ReviewComponent
      },
      {
        path: 'confirmation',
        canActivate: [EnrolmentGuard],
        component: ConfirmationComponent
      },
      {
        path: 'agreement',
        canActivate: [EnrolmentGuard],
        component: AccessAgreementComponent
      },
      {
        path: 'summary',
        canActivate: [EnrolmentGuard],
        component: SummaryComponent
      },
      {
        path: '', // Equivalent to `/` and alias for `profile`
        redirectTo: 'profile',
        pathMatch: 'full'
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EnrolmentRoutingModule { }
