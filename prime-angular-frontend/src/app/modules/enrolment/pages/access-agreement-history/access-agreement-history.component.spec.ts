import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccessAgreementHistoryComponent } from './access-agreement-history.component';
import { NgxBusyModule } from '@shared/modules/ngx-busy/ngx-busy.module';
import { PageComponent } from '@shared/components/page/page.component';
import { PageHeaderComponent } from '@shared/components/page-header/page-header.component';
import { AccessTermComponent } from '../access-agreement/components/access-term/access-term.component';
import { PageSubheaderComponent } from '@shared/components/page-subheader/page-subheader.component';
import { FormatDatePipe } from '@shared/pipes/format-date.pipe';
import { SafeHtmlPipe } from '@shared/pipes/safe-html.pipe';
import { NgxMaterialModule } from '@shared/modules/ngx-material/ngx-material.module';
import { NgxContextualHelpModule } from '@shared/modules/ngx-contextual-help/ngx-contextual-help.module';
import { APP_CONFIG, APP_DI_CONFIG } from 'app/app-config.module';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { EnrolmentService } from '@enrolment/shared/services/enrolment.service';
import { MockEnrolmentService } from 'test/mocks/mock-enrolment.service';

describe('AccessAgreementHistoryComponent', () => {
  let component: AccessAgreementHistoryComponent;
  let fixture: ComponentFixture<AccessAgreementHistoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule(
      {
        imports: [
          NgxBusyModule,
          NgxMaterialModule,
          NgxContextualHelpModule,
          HttpClientTestingModule,
          RouterTestingModule
        ],
        declarations: [
          AccessAgreementHistoryComponent,
          PageComponent,
          AccessTermComponent,
          PageHeaderComponent,
          PageSubheaderComponent,
          FormatDatePipe,
          SafeHtmlPipe
        ],
        providers: [
          {
            provide: APP_CONFIG,
            useValue: APP_DI_CONFIG
          },
          {
            provide: EnrolmentService,
            useClass: MockEnrolmentService
          },
        ]
      }
    ).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccessAgreementHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
