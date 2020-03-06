import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppRoutes } from './app.routes';
import { AccessDeniedComponent } from '@ui/components/access-denied/access-denied.component';
import { UnsupportedComponent } from '@ui/components/unsupported/unsupported.component';
import { MaintenanceComponent } from '@ui/components/maintenance/maintenance.component';
import { PageNotFoundComponent } from '@ui/components/page-not-found/page-not-found.component';
import { HelpComponent } from '@ui/components/help/help.component';
import { EnrolleeGuard } from '@enrolment/shared/guards/enrollee.guard';

const routes: Routes = [
  {
    path: AppRoutes.DENIED,
    component: AccessDeniedComponent,
    data: {
      title: 'Access Denied'
    }
  },
  {
    path: AppRoutes.UNSUPPORTED,
    component: UnsupportedComponent,
    data: {
      title: 'Unsupported Browser'
    }
  },
  {
    path: AppRoutes.MAINTENANCE,
    component: MaintenanceComponent,
    data: {
      title: 'Under Scheduled Maintenace'
    }
  },
  {
    // Allow for direct routing to page not found
    path: AppRoutes.PAGE_NOT_FOUND,
    component: PageNotFoundComponent,
    data: {
      title: 'Page Not Found'
    }
  },
  {
    path: AppRoutes.HELP,
    component: HelpComponent,
    data: {
      title: 'Help'
    }
  },
  {
    path: AppRoutes.DEFAULT,
    component: PageNotFoundComponent,
    data: {
      title: 'Page Not Found'
    }
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { enableTracing: false })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
