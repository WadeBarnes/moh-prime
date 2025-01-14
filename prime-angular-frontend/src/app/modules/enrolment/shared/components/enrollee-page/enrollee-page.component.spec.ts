import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';

import { EnrolleePageComponent } from './enrollee-page.component';
import { NgxBusyModule } from '@lib/modules/ngx-busy/ngx-busy.module';
import { SharedModule } from '@shared/shared.module';
import { RouterTestingModule } from '@angular/router/testing';
import { EnrolmentService } from '@enrolment/shared/services/enrolment.service';
import { MockEnrolmentService } from 'test/mocks/mock-enrolment.service';
import { NgxMaterialModule } from '@lib/modules/ngx-material/ngx-material.module';
import { APP_DI_CONFIG, APP_CONFIG } from 'app/app-config.module';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { KeycloakService } from 'keycloak-angular';

describe('EnrolleePageComponent', () => {
  let component: EnrolleePageComponent;
  let fixture: ComponentFixture<EnrolleePageComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule,
        RouterTestingModule,
        NgxBusyModule,
        NgxMaterialModule,
        SharedModule
      ],
      declarations: [EnrolleePageComponent],
      providers: [
        {
          provide: EnrolmentService,
          useClass: MockEnrolmentService
        },
        {
          provide: APP_CONFIG,
          useValue: APP_DI_CONFIG
        },
        KeycloakService
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EnrolleePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
